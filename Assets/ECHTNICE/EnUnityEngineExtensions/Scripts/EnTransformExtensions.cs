#if !(DISABLE_ALL_EN_EXTENSIONS || DISABLE_EN_TRANSFORM_EXTENSIONS)

namespace UnityEngine
{
    using System.Text;
    /// <summary>
    /// Utility extensions for manipulating and working with Transforms.
    ///
    /// <example>
    /// <code>
    /// ...
    /// </code>
    /// </example>
    /// 
    /// <example>
    /// <code>
    /// 
    /// #define DISABLE_ALL_EN_EXTENSIONS //Disable all Extensions
    /// #define DISABLE_EN_TRANSFORM_EXTENSIONS // Disable this Extensions
    /// 
    /// </code>
    /// </example>
    /// </summary>
    public static class EnTransformExtensions
    {

        /// <summary>
        /// Look at a GameObject
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target">The thing to look at</param>
        public static void LookAt(this Transform self, GameObject target)
        {
            self.LookAt(target.transform);
        }

        /// <summary>
        /// Find the rotation to look at a Vector3
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target">The thing to look at</param>
        /// <returns></returns>
        public static Quaternion GetLookAtRotation(this Transform self, Vector3 target)
        {
            return Quaternion.LookRotation(target - self.position);
        }

        /// <summary>
        /// Find the rotation to look at a Transform
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target">The thing to look at</param>
        /// <returns></returns>
        public static Quaternion GetLookAtRotation(this Transform self, Transform target)
        {
            return GetLookAtRotation(self, target.position);
        }

        /// <summary>
        /// Find the rotation to look at a GameObject
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target">The thing to look at</param>
        /// <returns></returns>
        public static Quaternion GetLookAtRotation(this Transform self, GameObject target)
        {
            return GetLookAtRotation(self, target.transform.position);
        }


        /// <summary>
        /// Instantly look away from a target Vector3
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target">The thing to look away from</param>
        public static void LookAwayFrom(this Transform self, Vector3 target)
        {
            self.rotation = GetLookAwayFromRotation(self, target);
        }

        /// <summary>
        /// Instantly look away from a target transform
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target">The thing to look away from</param>
        public static void LookAwayFrom(this Transform self, Transform target)
        {
            self.rotation = GetLookAwayFromRotation(self, target);
        }

        /// <summary>
        /// Instantly look away from a target GameObject
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target">The thing to look away from</param>
        public static void LookAwayFrom(this Transform self, GameObject target)
        {
            self.rotation = GetLookAwayFromRotation(self, target);
        }


        /// <summary>
        /// Find the rotation to look away from a target Vector3
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target">The thing to look away from</param>
        public static Quaternion GetLookAwayFromRotation(this Transform self, Vector3 target)
        {
            return Quaternion.LookRotation(self.position - target);
        }

        /// <summary>
        /// Find the rotation to look away from a target transform
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target">The thing to look away from</param>
        public static Quaternion GetLookAwayFromRotation(this Transform self, Transform target)
        {
            return GetLookAwayFromRotation(self, target.position);
        }

        /// <summary>
        /// Find the rotation to look away from a target GameObject
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target">The thing to look away from</param>
        public static Quaternion GetLookAwayFromRotation(this Transform self, GameObject target)
        {
            return GetLookAwayFromRotation(self, target.transform.position);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public static string GetTransformPath(this Transform transform) {
            StringBuilder sb = new StringBuilder(transform.name);
            while (transform.parent) {
                transform = transform.parent;
                sb.Insert(0, '/');
                sb.Insert(0, transform.name);
            }
            return sb.ToString();
        }
    }
}
#endif