#if !(DISABLE_ALL_EN_EXTENSIONS || DISABLE_EN_OBJECT_EXTENSIONS)
namespace UnityEngine {

    /// <summary>
    /// Utility extensions for manipulating and working with Objects
    /// 
    /// <example>
    /// <code>
    /// 
    /// #define DISABLE_ALL_EN_EXTENSIONS //Disable all Extensions
    /// #define DISABLE_EN_OBJECT_EXTENSIONS // Disable this Extensions
    /// 
    /// </code>
    /// </example>
    /// </summary>
    public static class EnObjectExtensions {

        public static bool IsNull(this Object obj) {
            return ((object)obj) == null;
        }

        public static bool IsNotNull(this Object obj) {
            return ((object)obj) != null;
        }

    }
}
#endif