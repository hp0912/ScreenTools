using System;
using System.Collections.Generic;
using NAudio.CoreAudioApi;

// ReSharper disable once CheckNamespace
namespace NAudio.Wave
{
    /// <summary>
    /// WASAPI Loopback Capture
    /// based on a contribution from "Pygmy" - http://naudio.codeplex.com/discussions/203605
    /// </summary>
    public class WasapiLoopbackCapture : WasapiCapture
    {
        /// <summary>
        /// Initialises a new instance of the WASAPI capture class
        /// </summary>
        public WasapiLoopbackCapture() :
            this(GetDefaultLoopbackCaptureDevice())
        {
        }

        /// <summary>
        /// Initialises a new instance of the WASAPI capture class
        /// </summary>
        public WasapiLoopbackCapture(bool isMixed) :
            base(GetDefaultLoopbackCaptureDevice2(), false, 100)
        {
        }

        /// <summary>
        /// Initialises a new instance of the WASAPI capture class
        /// </summary>
        /// <param name="captureDevice">Capture device to use</param>
        public WasapiLoopbackCapture(MMDevice captureDevice) :
            base(captureDevice)
        {
        }

        /// <summary>
        /// Gets the default audio loopback capture device
        /// </summary>
        /// <returns>The default audio loopback capture device</returns>
        public static MMDevice GetDefaultLoopbackCaptureDevice()
        {
            MMDeviceEnumerator devices = new MMDeviceEnumerator();
            return devices.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
        }

        /// <summary>
        /// Gets the default audio loopback capture device
        /// </summary>
        /// <returns>The default audio loopback capture device</returns>
        public static List<MMDevice> GetDefaultLoopbackCaptureDevice2()
        {
            MMDeviceEnumerator devices = new MMDeviceEnumerator();
            List<MMDevice> list = new List<MMDevice>();
            list.Add(devices.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia));
            list.Add(devices.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia));
            return list;
        }

        /// <summary>
        /// Capturing wave format
        /// </summary>
        public override WaveFormat WaveFormat
        {
            get { return base.WaveFormat; }
            set { throw new InvalidOperationException("WaveFormat cannot be set for WASAPI Loopback Capture"); }
        }
        
        /// <summary>
        /// Specify loopback
        /// </summary>
        protected override AudioClientStreamFlags GetAudioClientStreamFlags()
        {
            return AudioClientStreamFlags.Loopback;
        }        
    }
}
