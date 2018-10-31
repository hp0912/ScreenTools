using Captura;
using Captura.Audio;
using Captura.Models;
using Captura.ViewModels;
using Screna;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenTools
{
    class MyRecordingViewModel : ViewModelBase
    {

        IRecorder _recorder;
        readonly IVideoSourcePicker VideoSourcePicker;
        readonly LanguageManager LanguageManager = LanguageManager.Instance;
        readonly ISystemTray SystemTray = null;
        readonly IPreviewWindow _previewWindow;
        readonly WebcamOverlay _webcamOverlay;
        readonly AudioSource _audioSource;
        readonly IRegionProvider RegionProvider;
        readonly FullScreenSourceProvider FullScreenProvider;
        readonly ScreenSourceProvider ScreenSourceProvider;
        readonly WindowSourceProvider WindowSourceProvider;
        readonly RegionSourceProvider RegionSourceProvider;
        readonly NoVideoSourceProvider NoVideoSourceProvider;
        readonly DeskDuplSourceProvider DeskDuplSourceProvider;
        readonly IEnumerable<IImageWriterItem> ImageWriters;
        readonly FFmpegWriterProvider FFmpegWriterProvider;
        readonly GifWriterProvider GifWriterProvider;
        readonly StreamingWriterProvider StreamingWriterProvider;
        String FileSavePath;
        readonly SharpAviWriterProvider SharpAviWriterProvider = new SharpAviWriterProvider();

        readonly DiscardWriterProvider DiscardWriterProvider = new DiscardWriterProvider();

        VideoViewModel _videoViewModel;

        public MyRecordingViewModel(AudioSource audioSource) : base(new Settings(), LanguageManager.Instance)
        {
            _audioSource = audioSource;
            VideoSourcePicker = new VideoSourcePicker();
            //_audioSource = new BassAudioSource(Settings.Audio);
            RegionProvider = new RegionSelector(VideoSourcePicker);
            _webcamOverlay = new WebcamOverlay(new WebCamProvider(), Settings);
            _previewWindow = new PreviewWindowService();
            FullScreenProvider = new FullScreenSourceProvider(LanguageManager, new FullScreenItem());
            ScreenSourceProvider = new ScreenSourceProvider(LanguageManager, VideoSourcePicker);
            WindowSourceProvider = new WindowSourceProvider(LanguageManager, VideoSourcePicker, new RegionSelector(VideoSourcePicker));
            RegionSourceProvider = new RegionSourceProvider(LanguageManager, RegionProvider);
            NoVideoSourceProvider = new NoVideoSourceProvider(LanguageManager);
            DeskDuplSourceProvider = new DeskDuplSourceProvider(LanguageManager, VideoSourcePicker);
            ImageWriters = new IImageWriterItem[4] { new EditorWriter(), new ClipboardWriter(SystemTray, LanguageManager), null, null };
            SharpAviWriterProvider = new SharpAviWriterProvider();
            DiscardWriterProvider = new DiscardWriterProvider();
            FFmpegWriterProvider = new FFmpegWriterProvider(new FFmpegSettings());
            GifWriterProvider = new GifWriterProvider(LanguageManager, new GifItem(new GifSettings()));
            StreamingWriterProvider = new StreamingWriterProvider();
            _videoViewModel = new VideoViewModel(
                RegionProvider,
                ImageWriters,
                Settings,
                LanguageManager,
                FullScreenProvider,
                ScreenSourceProvider,
                WindowSourceProvider,
                RegionSourceProvider,
                NoVideoSourceProvider,
                DeskDuplSourceProvider,
                FFmpegWriterProvider,
                SharpAviWriterProvider,
                GifWriterProvider,
                StreamingWriterProvider,
                DiscardWriterProvider
                );
        }
        public CustomOverlaysViewModel CustomOverlays { get; }
        public CustomImageOverlaysViewModel CustomImageOverlays { get; }

        public void StartRecoding(String savePath)
        {
            FileSavePath = savePath + "BAR-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".avi";

            //图像
            IImageProvider imgProvider = null;

            try
            {
                imgProvider = GetImageProvider();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                imgProvider?.Dispose();
                return;
            }
            //声音
            IAudioProvider audioProvider = null;

            try
            {
                Settings.Audio.Enabled = true;
                if (Settings.Audio.Enabled && !Settings.Audio.SeparateFilePerSource)
                {
                    audioProvider = _audioSource.GetMixedAudioProvider();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                _audioSource?.Dispose();
                return;
            }
            //视频写入
            IVideoFileWriter videoEncoder;

            try
            {
                videoEncoder = GetVideoFileWriterWithPreview(imgProvider, audioProvider);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                imgProvider?.Dispose();
                audioProvider?.Dispose();

                return;
            }

            _recorder = new Recorder(videoEncoder, imgProvider, Settings.Video.FrameRate, audioProvider);
            _recorder.Start();
        }

        public async Task StopAudioRecording(IRecorder _recorder)
        {
            // Reference Recorder as it will be set to null
            var rec = _recorder;
            var task = Task.Run(() => rec.Dispose());

            _recorder = null;

            try
            {
                await task;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
        }

        public async Task StopAudioRecording()
        {
            // Reference Recorder as it will be set to null
            var rec = _recorder;
            var task = Task.Run(() => rec.Dispose());

            _recorder = null;

            try
            {
                await task;
            }
            catch (Exception e)
            { 
                MessageBox.Show(e.Message);
                return;
            }
        }


        IImageProvider GetImageProvider()
        {
            Func<Point, Point> transform = P => P;

            var imageProvider = _videoViewModel.SelectedVideoSourceKind?.Source?.GetImageProvider(Settings.IncludeCursor, out transform);

            if (imageProvider == null)
                return null;

            var overlays = new List<IOverlay>
            {
                new CensorOverlay(Settings.Censored)
            };

            if (!Settings.WebcamOverlay.SeparateFile)
            {
                overlays.Add(_webcamOverlay);
            }

            overlays.Add(new MousePointerOverlay(Settings.MousePointerOverlay));
            // Custom Image Overlays

            return new OverlayedImageProvider(imageProvider, transform, overlays.ToArray());
        }

        IVideoFileWriter GetVideoFileWriterWithPreview(IImageProvider ImgProvider, IAudioProvider AudioProvider)
        {
            if (_videoViewModel.SelectedVideoSourceKind is NoVideoSourceProvider)
                return null;

            _previewWindow.Init(ImgProvider.Width, ImgProvider.Height);

            return new WithPreviewWriter(GetVideoFileWriter(ImgProvider, AudioProvider, FileSavePath), _previewWindow);
        }

        IVideoFileWriter GetVideoFileWriter(IImageProvider ImgProvider, IAudioProvider AudioProvider, string FileName)
        {
            if (_videoViewModel.SelectedVideoSourceKind is NoVideoSourceProvider)
                return null;

            _videoViewModel.SelectedVideoWriterKind = SharpAviWriterProvider;
            return (SharpAviWriterProvider.Last()).GetVideoFileWriter(new VideoWriterArgs
            {
                FileName = FileName,
                FrameRate = Settings.Video.FrameRate,
                VideoQuality = Settings.Video.Quality,
                ImageProvider = ImgProvider,
                AudioQuality = Settings.Audio.Quality,
                AudioProvider = AudioProvider
            });
        }
    }
}
