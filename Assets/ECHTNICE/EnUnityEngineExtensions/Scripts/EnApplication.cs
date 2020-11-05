#if !(DISABLE_ALL_EN_EXTENSIONS || DISABLE_EN_Application) 
namespace UnityEngine {
    using System;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// EnApplication is a Helper Class
    /// 
    /// <example>
    /// <code>
    /// EnApplication.SetTargetFrameRate120();
    /// EnApplication.LogSystemInfo()
    /// </code>
    /// </example>
    /// </summary>
    public static class EnApplication {

        /// <summary>
        /// Open browser.
        /// url is urlencoded.
        /// </summary>
        public static void OpenUrlWithEscapeUri(string url) {
            Application.OpenURL(Uri.EscapeUriString(url));
        }

        /// <summary>
        /// Set 120 target frame rate.
        /// </summary>
        public static void SetTargetFrameRate120() {
            SetTargetFrameRate(120);
        }

        /// <summary>
        /// Set 60 target frame rate.
        /// </summary>
        public static void SetTargetFrameRate60() {
            SetTargetFrameRate(60);
        }

        /// <summary>
        /// Set 30 target frame rate.
        /// </summary>
        public static void SetTargetFrameRate30() {
            SetTargetFrameRate(30);
        }

        /// <summary>
        /// Set target frame rate.
        /// </summary>
        /// <param name="frameRate"></param>
        public static void SetTargetFrameRate(int frameRate) {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = frameRate;
        }

        /// <summary>
        ///
        /// Low 2ms
        /// BelowNormal 4ms
        /// Normal 10ms
        /// High 50ms
        ///
        /// </summary>
        /// <param name="threadPriority"></param>
        public static void SetBackgroundLoadingPriority(ThreadPriority threadPriority) {
            Application.backgroundLoadingPriority = threadPriority;
        }


        /// <summary>
        /// Shows a log about the system info.
        /// </summary>
#if UNITY_EDITOR || !DEVELOPMENT_BUILD
        [Conditional("UNITY_EDITOR")]
#endif
        public static void LogSystemInfo() {
            Debug.Log(GetSystemInfoToString);
        }

        /// <summary>
        /// System info list to String.
        /// </summary>
        public static string GetSystemInfoToString {
            get {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine("[deviceModel]" + SystemInfo.deviceModel);
                builder.AppendLine("[deviceName]" + SystemInfo.deviceName);
                builder.AppendLine("[deviceType]" + SystemInfo.deviceType);
                builder.AppendLine("[graphicsDeviceId]" + SystemInfo.graphicsDeviceID);
                builder.AppendLine("[graphicsDeviceName]" + SystemInfo.deviceModel);
                builder.AppendLine("[graphicsDeviceVendor]" + SystemInfo.graphicsDeviceVendor);
                builder.AppendLine("[graphicsDeviceVendorId]" + SystemInfo.graphicsDeviceVendorID);
                builder.AppendLine("[graphicsDeviceVersion]" + SystemInfo.graphicsDeviceVersion);
                builder.AppendLine("[graphicsMemorySize]" + SystemInfo.graphicsMemorySize);
                builder.AppendLine("[graphicsShaderLevel]" + SystemInfo.graphicsShaderLevel);
                builder.AppendLine("[operatingSystem]" + SystemInfo.operatingSystem);
                builder.AppendLine("[processorCount]" + SystemInfo.processorCount);
                builder.AppendLine("[processorType]" + SystemInfo.processorType);
                builder.AppendLine("[supportedRenderTargetCount]" + SystemInfo.supportedRenderTargetCount);
                builder.AppendLine("[supports3dTextures]" + SystemInfo.supports3DTextures);
                builder.AppendLine("[supportsAccelerometer]" + SystemInfo.supportsAccelerometer);
                builder.AppendLine("[supportsComputeShaders]" + SystemInfo.supportsComputeShaders);
                builder.AppendLine("[supportsGyroscope]" + SystemInfo.supportsGyroscope);
                builder.AppendLine("[supportsInstancing]" + SystemInfo.supportsInstancing);
                builder.AppendLine("[supportsLocationService]" + SystemInfo.supportsLocationService);
                builder.AppendLine("[supportsShadows]" + SystemInfo.supportsShadows);
                builder.AppendLine("[supportsVibration]" + SystemInfo.supportsVibration);
                builder.AppendLine("[systemMemorySize]" + SystemInfo.systemMemorySize);
                builder.AppendLine($"[Screen] {Screen.width}×{Screen.height}");
                builder.AppendLine($"[ScreenCurrentResolution] {Screen.currentResolution.width}×{Screen.currentResolution.height}");

                builder.AppendLine("[SupportsTextureFormat]");

                foreach (TextureFormat textureFormat in Enum.GetValues(typeof(TextureFormat)))
                {
                    try
                    {
                        builder.AppendLine($"- [{textureFormat}]: " + SystemInfo.SupportsTextureFormat(textureFormat));
                    }
                    catch
                    {
                        builder.AppendLine($"- [{textureFormat}]: EXCEPTION");
                    }
                }

                return builder.ToString();
            }
        }
    }
}
#endif