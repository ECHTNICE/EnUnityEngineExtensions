#if !(DISABLE_ALL_EN_EXTENSIONS || DISABLE_EN_COLOR_EXTENSIONS)
namespace UnityEngine {

    /// <summary>
    /// Utility extensions for manipulating and working with Transforms.
    ///
    /// <example>
    /// <code>
    /// string hexColor = Color.red.ToHex();
    /// </code>
    /// </example>
    /// 
    /// <example>
    /// <code>
    /// 
    /// #define DISABLE_ALL_EN_EXTENSIONS //Disable all Extensions
    /// #define DISABLE_EN_COLOR_EXTENSIONS // Disable this Extensions
    /// 
    /// </code>
    /// </example>
    /// </summary>
    public static class EnColorExtensions {
        #region Constants

        const float LightOffset = 0.0625f;
        const float DarkerFactor = 0.9f;

        #endregion


        public static Color SetR(this Color c, float r) {
            return new Color(r, c.g, c.b, c.a);
        }

        public static Color SetG(this Color c, float g) {
            return new Color(c.r, g, c.b, c.a);
        }

        public static Color SetB(this Color c, float b) {
            return new Color(c.r, c.g, b, c.a);
        }

        public static Color SetA(this Color c, float a) {
            return new Color(c.r, c.g, c.b, a);
        }


        public static string ToHex(this Color self) {
            int i = 0xFFFFFF & (self.ToInt() >> 8);
            return i.ToString("X4");
        }

        /// <summary>
        /// 
        /// </summary>
        public static int ToInt(this Color self) {
            int result = 0;
            result |= Mathf.RoundToInt(self.r * 255f) << 24;
            result |= Mathf.RoundToInt(self.g * 255f) << 16;
            result |= Mathf.RoundToInt(self.b * 255f) << 8;
            result |= Mathf.RoundToInt(self.a * 255f);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The RGB.</returns>
        /// <param name="red">Red.</param>
        /// <param name="green">Green.</param>
        /// <param name="blue">Blue.</param>
        public static Color RGBToColor(int red, int green, int blue) {
            return new Color(red / 255f, green / 255f, blue / 255f);
        }

        /// <summary>
        /// #
        /// </summary>
        /// <returns>The hex to RG.</returns>
        /// <param name="hex">Hex.</param>
        public static Color HexToColor(string hex) {
            if (string.IsNullOrEmpty(hex)) {
                return Color.white;
            }

            hex = hex.Replace("0x", ""); //in case the string is formatted 0xFFFFFF
            hex = hex.Replace("#", ""); //in case the string is formatted #FFFFFF
            byte a = 255; //assume fully visible unless specified in hex
            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

            //Only use alpha if the string has enough characters
            if (hex.Length == 8) {
                a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            }

            return new Color32(r, g, b, a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color">Color.</param>
        public static Color Lighter(this Color color) {
            return new Color(color.r + LightOffset, color.g + LightOffset, color.b + LightOffset, color.a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color">Color.</param>
        public static Color Darker(this Color color) {
            return new Color(color.r - DarkerFactor, color.g - DarkerFactor, color.b - DarkerFactor, color.a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color">Color.</param>
        public static float Brightness(this Color color) {
            return (color.r + color.g + color.b) / 3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The brightness.</returns>
        /// <param name="color">Color.</param>
        /// <param name="brightness">Brightness.</param>
        public static Color WithBrightness(this Color color, float brightness) {
            float brigth = Mathf.Clamp01(brightness);

            if (color.IsApproximatelyBlack()) {
                return new Color(brigth, brigth, brigth, color.a);
            }

            float factor = brigth / color.Brightness();

            float r = color.r * factor;
            float g = color.g * factor;
            float b = color.b * factor;

            float a = color.a;

            return new Color(r, g, b, a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns><c>true</c> if is approximately black the specified color; otherwise, <c>false</c>.</returns>
        /// <param name="color">Color.</param>
        public static bool IsApproximatelyBlack(this Color color) {
            return color.r + color.g + color.b <= Mathf.Epsilon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns><c>true</c> if is approximately white the specified color; otherwise, <c>false</c>.</returns>
        /// <param name="color">Color.</param>
        public static bool IsApproximatelyWhite(this Color color) {
            return color.r + color.g + color.b >= 1 - Mathf.Epsilon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color">Color.</param>
        public static Color Opaque(this Color color) {
            return new Color(color.r, color.g, color.b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The alpha.</returns>
        /// <param name="color">Color.</param>
        /// <param name="alpha">Alpha.</param>
        public static Color WithAlpha(this Color color, float alpha) {
            return new Color(color.r, color.g, color.b, Mathf.Clamp01(alpha));
        }
    }
}
#endif