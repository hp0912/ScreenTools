using System;
using NAudio.Wave;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using NAudio.Wave.SampleProviders;

// for consistency this should be in NAudio.Wave namespace, but left as it is for backwards compatibility
// ReSharper disable once CheckNamespace
namespace NAudio.CoreAudioApi
{
    /// <summary>
    /// Represents state of a capture device
    /// </summary>
    public enum CaptureState
    {
        /// <summary>
        /// Not recording
        /// </summary>
        Stopped,
        /// <summary>
        /// Beginning to record
        /// </summary>
        Starting,
        /// <summary>
        /// Recording in progress
        /// </summary>
        Capturing,
        /// <summary>
        /// Requesting stop
        /// </summary>
        Stopping
    }

    /// <summary>
    /// Audio Capture using Wasapi
    /// See http://msdn.microsoft.com/en-us/library/dd370800%28VS.85%29.aspx
    /// </summary>
    public class WasapiCapture : IWaveIn
    {
        private const long ReftimesPerSec = 10000000;
        private const long ReftimesPerMillisec = 10000;
        private volatile CaptureState captureState;
        private byte[] recordBuffer;
        private byte[] recordBuffer2;
        private Thread captureThread;
        private AudioClient audioClient;
        private List<AudioClient> audioClientList;
        private int bytesPerFrame;
        private int bytesPerFrame2;
        private WaveFormat waveFormat;
        private List<WaveFormat> waveFormatList;
        private bool initialized;
        private readonly SynchronizationContext syncContext;
        private readonly bool isUsingEventSync;
        private EventWaitHandle frameEventWaitHandle;
        private readonly int audioBufferMillisecondsLength;
        private bool isMixed = false;

        /// <summary>
        /// Indicates recorded data is available 
        /// </summary>
        public event EventHandler<WaveInEventArgs> DataAvailable;

        /// <summary>
        /// Indicates that all recorded data has now been received.
        /// </summary>
        public event EventHandler<StoppedEventArgs> RecordingStopped;

        /// <summary>
        /// Initialises a new instance of the WASAPI capture class
        /// </summary>
        public WasapiCapture() : 
            this(GetDefaultCaptureDevice())
        {
        }

        /// <summary>
        /// Initialises a new instance of the WASAPI capture class
        /// </summary>
        /// <param name="captureDevice">Capture device to use</param>
        public WasapiCapture(MMDevice captureDevice)
            : this(captureDevice, false)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WasapiCapture"/> class.
        /// </summary>
        /// <param name="captureDevice">The capture device.</param>
        /// <param name="useEventSync">true if sync is done with event. false use sleep.</param>
        public WasapiCapture(MMDevice captureDevice, bool useEventSync) 
            : this(captureDevice, useEventSync, 100)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WasapiCapture" /> class.
        /// </summary>
        /// <param name="captureDevice">The capture device.</param>
        /// <param name="useEventSync">true if sync is done with event. false use sleep.</param>
        /// <param name="audioBufferMillisecondsLength">Length of the audio buffer in milliseconds. A lower value means lower latency but increased CPU usage.</param>
        public WasapiCapture(MMDevice captureDevice, bool useEventSync, int audioBufferMillisecondsLength)
        {
            syncContext = SynchronizationContext.Current;
            audioClient = captureDevice.AudioClient;
            ShareMode = AudioClientShareMode.Shared;
            isUsingEventSync = useEventSync;
            this.audioBufferMillisecondsLength = audioBufferMillisecondsLength;

            waveFormat = audioClient.MixFormat;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WasapiCapture" /> class.
        /// </summary>
        /// <param name="captureDeviceList">The capture device.</param>
        /// <param name="useEventSync">true if sync is done with event. false use sleep.</param>
        /// <param name="audioBufferMillisecondsLength">Length of the audio buffer in milliseconds. A lower value means lower latency but increased CPU usage.</param>
        public WasapiCapture(List<MMDevice> captureDeviceList, bool useEventSync, int audioBufferMillisecondsLength)
        {
            syncContext = SynchronizationContext.Current;
            audioClientList = new List<AudioClient>();
            audioClientList.Add(captureDeviceList[0].AudioClient);
            audioClientList.Add(captureDeviceList[1].AudioClient);
            ShareMode = AudioClientShareMode.Shared;
            isUsingEventSync = useEventSync;
            this.audioBufferMillisecondsLength = audioBufferMillisecondsLength;

            waveFormatList = new List<WaveFormat>();
            waveFormatList.Add(audioClientList[0].MixFormat);
            waveFormatList.Add(audioClientList[1].MixFormat);
            // waveFormatList.Add(new WaveFormat(waveFormatList[0].SampleRate, 16, waveFormatList[0].Channels));

            isMixed = true;

        }

        /// <summary>
        /// Share Mode - set before calling StartRecording
        /// </summary>
        public AudioClientShareMode ShareMode { get; set; }

        /// <summary>
        /// Current Capturing State
        /// </summary>
        public CaptureState CaptureState {  get { return captureState; } }

        /// <summary>
        /// Capturing wave format
        /// </summary>
        public virtual WaveFormat WaveFormat 
        {
            get
            {
                // for convenience, return a WAVEFORMATEX, instead of the real
                // WAVEFORMATEXTENSIBLE being used
                if (isMixed)
                {
                    return waveFormatList[0].AsStandardWaveFormat();
                }
                else
                {
                    return waveFormat.AsStandardWaveFormat();
                }
            }
            set {
                if (isMixed)
                {
                    waveFormatList[0] = value;
                }
                else
                {
                    waveFormat = value;
                }
            }
        }
        
        /// <summary>
        /// Gets the default audio capture device
        /// </summary>
        /// <returns>The default audio capture device</returns>
        public static MMDevice GetDefaultCaptureDevice()
        {
            var devices = new MMDeviceEnumerator();
            return devices.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Console);
        }

        private void InitializeCaptureDevice()
        {
            if (initialized)
                return;
            
            if (isMixed)
            {
                long requestedDuration = ReftimesPerMillisec * audioBufferMillisecondsLength;

                if (!audioClientList[0].IsFormatSupported(ShareMode, waveFormatList[0]) || !audioClientList[1].IsFormatSupported(ShareMode, waveFormatList[1]))
                {
                    throw new ArgumentException("Unsupported Wave Format");
                }

                var streamFlags = GetAudioClientStreamFlags();

                // Normal setup for both sharedMode
                audioClientList[0].Initialize(ShareMode,
                streamFlags,
                requestedDuration,
                0,
                waveFormatList[0],
                Guid.Empty);

                audioClientList[1].Initialize(ShareMode,
                AudioClientStreamFlags.None,
                requestedDuration,
                0,
                waveFormatList[1],
                Guid.Empty);

                int bufferFrameCount = audioClientList[0].BufferSize;
                bytesPerFrame = waveFormatList[0].Channels * waveFormatList[0].BitsPerSample / 8;
                int bufferFrameCount2 = audioClientList[1].BufferSize;
                bytesPerFrame2 = waveFormatList[1].Channels * waveFormatList[1].BitsPerSample / 8;

                //recordBuffer = new byte[bufferFrameCount * bytesPerFrame + bufferFrameCount2 * bytesPerFrame2];
                recordBuffer = new byte[bufferFrameCount * bytesPerFrame];
                recordBuffer2 = new byte[bufferFrameCount2 * bytesPerFrame2];
            }
            else
            {
                long requestedDuration = ReftimesPerMillisec * audioBufferMillisecondsLength;

                if (!audioClient.IsFormatSupported(ShareMode, waveFormat))
                {
                    throw new ArgumentException("Unsupported Wave Format");
                }

                var streamFlags = GetAudioClientStreamFlags();

                // If using EventSync, setup is specific with shareMode
                if (isUsingEventSync)
                {
                    // Init Shared or Exclusive
                    if (ShareMode == AudioClientShareMode.Shared)
                    {
                        // With EventCallBack and Shared, both latencies must be set to 0
                        audioClient.Initialize(ShareMode, AudioClientStreamFlags.EventCallback | streamFlags, requestedDuration, 0,
                            waveFormat, Guid.Empty);
                    }
                    else
                    {
                        // With EventCallBack and Exclusive, both latencies must equals
                        audioClient.Initialize(ShareMode, AudioClientStreamFlags.EventCallback | streamFlags, requestedDuration, requestedDuration,
                                            waveFormat, Guid.Empty);
                    }

                    // Create the Wait Event Handle
                    frameEventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
                    audioClient.SetEventHandle(frameEventWaitHandle.SafeWaitHandle.DangerousGetHandle());
                }
                else
                {
                    // Normal setup for both sharedMode
                    audioClient.Initialize(ShareMode,
                    streamFlags,
                    requestedDuration,
                    0,
                    waveFormat,
                    Guid.Empty);
                }

                int bufferFrameCount = audioClient.BufferSize;
                bytesPerFrame = waveFormat.Channels * waveFormat.BitsPerSample / 8;
                recordBuffer = new byte[bufferFrameCount * bytesPerFrame];
            }

            //Debug.WriteLine(string.Format("record buffer size = {0}", this.recordBuffer.Length));

            initialized = true;
        }

        /// <summary>
        /// To allow overrides to specify different flags (e.g. loopback)
        /// </summary>
        protected virtual AudioClientStreamFlags GetAudioClientStreamFlags()
        {
            return AudioClientStreamFlags.None;
        }

        /// <summary>
        /// Start Capturing
        /// </summary>
        public void StartRecording()
        {
            if (captureState != CaptureState.Stopped)
            {
                throw new InvalidOperationException("Previous recording still in progress");
            }
            captureState = CaptureState.Starting;
            InitializeCaptureDevice();
            if (isMixed)
            {
                ThreadStart start = () => CaptureThread2(audioClientList);
                captureThread = new Thread(start);
                captureThread.Start();
            }
            else
            {
                ThreadStart start = () => CaptureThread(audioClient);
                captureThread = new Thread(start);
                captureThread.Start();
            }
        }

        /// <summary>
        /// Stop Capturing (requests a stop, wait for RecordingStopped event to know it has finished)
        /// </summary>
        public void StopRecording()
        {
            //using (var reader1 = new AudioFileReader(@"C:\Users\BEPSUNP24\AppData\Local\Temp\NAudioDemo\WasapiLoopbackCapture 48kHz stereo 2018-10-19 17-47-54.wav"))
            //using (var reader2 = new AudioFileReader(@"C:\Users\BEPSUNP24\AppData\Local\Temp\NAudioDemo\WasapiLoopbackCapture 48kHz stereo 2018-10-19 17-48-27.wav"))
            //{
            //    var mixer = new MixingSampleProvider(new[] { reader1, reader2 });
            //    WaveFileWriter.CreateWaveFile16(@"C:\Users\BEPSUNP24\AppData\Local\Temp\NAudioDemo\aaaaa.wav", mixer);
            //}

            if (captureState != CaptureState.Stopped)
                captureState = CaptureState.Stopping;
        }

        private void CaptureThread(AudioClient client)
        {
            Exception exception = null;
            try
            {
                DoRecording(client);
            }
            catch (Exception e)
            {
                exception = e;
            }
            finally
            {
                client.Stop();
                // don't dispose - the AudioClient only gets disposed when WasapiCapture is disposed
            }
            captureThread = null;
            captureState = CaptureState.Stopped;
            RaiseRecordingStopped(exception);
        }

        private void CaptureThread2(List<AudioClient> clientList)
        {
            Exception exception = null;
            try
            {
                DoRecording2(clientList);
            }
            catch (Exception e)
            {
                exception = e;
            }
            finally
            {
                clientList[0].Stop();
                clientList[1].Stop();
                // don't dispose - the AudioClient only gets disposed when WasapiCapture is disposed
            }
            captureThread = null;
            captureState = CaptureState.Stopped;
            RaiseRecordingStopped(exception);
        }

        private void DoRecording(AudioClient client)
        {
            //Debug.WriteLine(String.Format("Client buffer frame count: {0}", client.BufferSize));
            int bufferFrameCount = client.BufferSize;

            // Calculate the actual duration of the allocated buffer.
            long actualDuration = (long)((double)ReftimesPerSec *
                             bufferFrameCount / waveFormat.SampleRate);
            int sleepMilliseconds = (int)(actualDuration / ReftimesPerMillisec / 2);
            int waitMilliseconds = (int)(3 * actualDuration / ReftimesPerMillisec);

            var capture = client.AudioCaptureClient;
            client.Start();
            captureState = CaptureState.Capturing;
            while (captureState == CaptureState.Capturing)
            {
                bool readBuffer = true;
                if (isUsingEventSync)
                {
                    readBuffer = frameEventWaitHandle.WaitOne(waitMilliseconds, false);
                }
                else
                {
                    Thread.Sleep(sleepMilliseconds);
                }
                if (captureState != CaptureState.Capturing)
                    break;

                // If still recording and notification is ok
                if (readBuffer)
                {
                    ReadNextPacket(capture);
                }
            }
        }

        private void DoRecording2(List<AudioClient> clientList)
        {
            //Debug.WriteLine(String.Format("Client buffer frame count: {0}", client.BufferSize));
            int bufferFrameCount1 = clientList[0].BufferSize;
            int bufferFrameCount2 = clientList[1].BufferSize;

            // Calculate the actual duration of the allocated buffer.
            long actualDuration1 = (long)((double)ReftimesPerSec *
                             bufferFrameCount1 / waveFormatList[0].SampleRate);
            int sleepMilliseconds1 = (int)(actualDuration1 / ReftimesPerMillisec);
            int waitMilliseconds1 = (int)(3 * actualDuration1 / ReftimesPerMillisec);

            long actualDuration2 = (long)((double)ReftimesPerSec *
                             bufferFrameCount2 / waveFormatList[1].SampleRate);
            int sleepMilliseconds2 = (int)(actualDuration1 / ReftimesPerMillisec);
            int waitMilliseconds2 = (int)(3 * actualDuration1 / ReftimesPerMillisec);

            var capture1 = clientList[0].AudioCaptureClient;
            clientList[0].Start();
            var capture2 = clientList[1].AudioCaptureClient;
            clientList[1].Start();

            captureState = CaptureState.Capturing;
            while (captureState == CaptureState.Capturing)
            {
                bool readBuffer = true;
                Thread.Sleep(Math.Max(sleepMilliseconds1, sleepMilliseconds2) / 2);
                if (captureState != CaptureState.Capturing)
                    break;

                // If still recording and notification is ok
                if (readBuffer)
                {
                    ReadNextPacket2(capture1, capture2);
                }
            }
        }

        private void RaiseRecordingStopped(Exception e)
        {
            var handler = RecordingStopped;
            if (handler == null) return;
            if (syncContext == null)
            {
                handler(this, new StoppedEventArgs(e));
            }
            else
            {
                syncContext.Post(state => handler(this, new StoppedEventArgs(e)), null);
            }
        }

        private void ReadNextPacket(AudioCaptureClient capture)
        {
            int packetSize = capture.GetNextPacketSize();
            int recordBufferOffset = 0;
            //Debug.WriteLine(string.Format("packet size: {0} samples", packetSize / 4));

            while (packetSize != 0)
            {
                int framesAvailable;
                AudioClientBufferFlags flags;
                IntPtr buffer = capture.GetBuffer(out framesAvailable, out flags);

                int bytesAvailable = framesAvailable * bytesPerFrame;

                // apparently it is sometimes possible to read more frames than we were expecting?
                // fix suggested by Michael Feld:
                int spaceRemaining = Math.Max(0, recordBuffer.Length - recordBufferOffset);
                if (spaceRemaining < bytesAvailable && recordBufferOffset > 0)
                {
                    if (DataAvailable != null) DataAvailable(this, new WaveInEventArgs(recordBuffer, recordBufferOffset));
                    recordBufferOffset = 0;
                }

                // if not silence...
                if ((flags & AudioClientBufferFlags.Silent) != AudioClientBufferFlags.Silent)
                {
                    Marshal.Copy(buffer, recordBuffer, recordBufferOffset, bytesAvailable);
                }
                else
                {
                    Array.Clear(recordBuffer, recordBufferOffset, bytesAvailable);
                }
                recordBufferOffset += bytesAvailable;
                capture.ReleaseBuffer(framesAvailable);
                packetSize = capture.GetNextPacketSize();
            }
            if (DataAvailable != null)
            {
                DataAvailable(this, new WaveInEventArgs(recordBuffer, recordBufferOffset));
            }
        }

        private void ReadNextPacket2(AudioCaptureClient capture1, AudioCaptureClient capture2)
        {
            int packetSize1 = capture1.GetNextPacketSize();
            int packetSize2 = capture2.GetNextPacketSize();
            int recordBufferOffset = 0;
            int recordBufferOffset2 = 0;

            while (packetSize1 != 0 || packetSize2 != 0)
            {
                int framesAvailable1;
                AudioClientBufferFlags flags1;
                int framesAvailable2;
                AudioClientBufferFlags flags2;
                IntPtr buffer1 = capture1.GetBuffer(out framesAvailable1, out flags1);
                IntPtr buffer2 = capture2.GetBuffer(out framesAvailable2, out flags2);

                int bytesAvailable1 = framesAvailable1 * bytesPerFrame;
                int bytesAvailable2 = framesAvailable2 * bytesPerFrame2;

                // apparently it is sometimes possible to read more frames than we were expecting?
                // fix suggested by Michael Feld:
                int spaceRemaining = Math.Max(0, recordBuffer.Length - recordBufferOffset);
                int spaceRemaining2 = Math.Max(0, recordBuffer2.Length - recordBufferOffset2);
                if ((spaceRemaining < bytesAvailable1 && recordBufferOffset > 0) || (spaceRemaining2 < bytesAvailable2 && recordBufferOffset2 > 0))
                {
                    int outputIndex = 0;
                    int maxLen = Math.Max(recordBufferOffset, recordBufferOffset2);
                    var destWaveBuffer = new WaveBuffer(new byte[maxLen]);

                    for (int i = 0; i < maxLen; i += 4)
                    {
                        float a, b;

                        if (i < recordBuffer.Length)
                        {
                            a = BitConverter.ToSingle(recordBuffer, i);
                        }
                        else
                        {
                            a = 0;
                        }

                        if (i < recordBuffer2.Length)
                        {
                            b = BitConverter.ToSingle(recordBuffer2, i);
                        }
                        else
                        {
                            b = 0;
                        }

                        destWaveBuffer.ShortBuffer[outputIndex++] = (short)((a + b) * 32767 / 2);
                    }
                    if (DataAvailable != null) DataAvailable(this, new WaveInEventArgs(destWaveBuffer.ByteBuffer, maxLen));
                    recordBufferOffset = 0;
                    recordBufferOffset2 = 0;
                }

                // if not silence...
                if (packetSize1 != 0 && (flags1 & AudioClientBufferFlags.Silent) != AudioClientBufferFlags.Silent)
                {
                    Marshal.Copy(buffer1, recordBuffer, recordBufferOffset, bytesAvailable1);
                }
                if (packetSize2 != 0 && (flags2 & AudioClientBufferFlags.Silent) != AudioClientBufferFlags.Silent)
                {
                    Marshal.Copy(buffer2, recordBuffer2, recordBufferOffset2, bytesAvailable2);
                }
                if ((flags1 & AudioClientBufferFlags.Silent) == AudioClientBufferFlags.Silent)
                {
                    Array.Clear(recordBuffer, recordBufferOffset, bytesAvailable1);
                }
                if ((flags2 & AudioClientBufferFlags.Silent) == AudioClientBufferFlags.Silent)
                {
                    Array.Clear(recordBuffer2, recordBufferOffset2, bytesAvailable2);
                }
                
                recordBufferOffset += bytesAvailable1;
                recordBufferOffset2 += bytesAvailable2;

                capture1.ReleaseBuffer(framesAvailable1);
                capture2.ReleaseBuffer(framesAvailable2);
                packetSize1 = capture1.GetNextPacketSize();
                packetSize2 = capture2.GetNextPacketSize();
            }
            
            if (DataAvailable != null)
            {
                int outputIndex = 0;
                int maxLen = Math.Max(recordBufferOffset, recordBufferOffset2);
                var destWaveBuffer = new WaveBuffer(new byte[maxLen / 2]);

                for (int i = 0; i < maxLen; i += 4)
                {
                    float a, b;

                    if (i < recordBuffer.Length)
                    {
                        a = BitConverter.ToSingle(recordBuffer, i);
                    }
                    else
                    {
                        a = 0;
                    }

                    if (i < recordBuffer2.Length)
                    {
                        b = BitConverter.ToSingle(recordBuffer2, i);
                    }
                    else
                    {
                        b = 0;
                    }

                    destWaveBuffer.ShortBuffer[outputIndex++] = (short)((a + b) * 32767 / 2);
                }

                DataAvailable(this, new WaveInEventArgs(destWaveBuffer.ByteBuffer, maxLen / 2));
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            StopRecording();
            if (captureThread != null)
            {
                captureThread.Join();
                captureThread = null;
            }
            if (audioClient != null)
            {
                audioClient.Dispose();
                audioClient = null;
            }
            if (audioClientList != null)
            {
                audioClientList[0].Dispose();
                audioClientList[1].Dispose();
                audioClientList.Clear();
            }
        }
    }
}
