#if !(DISABLE_ALL_EN_EXTENSIONS || DISABLE_EN_VECTOR2_EXTENSIONS) 
namespace UnityEngine {
    public static class EnVector2Extensions  {

        #region Vector2 extension methods

        /// <summary>
        /// Distance to a second point.
        /// </summary>
        /// <param name="v">Origin point.</param>
        /// <param name="u">Destination point.</param>
        /// <returns>The distance from origin to destination.</returns>
        public static float Distance(this Vector2 v, Vector2 u) {
            return (u - v).magnitude;
        }

        /// <summary>
        /// Squared distance to a second point.
        /// </summary>
        /// <param name="v">Origin point.</param>
        /// <param name="u">Destination point.</param>
        /// <returns>The squared distance from origin to destination.</returns>
        public static float SqrDistance(this Vector2 v, Vector2 u) {
            return (u - v).sqrMagnitude;
        }

        /// <summary>
        /// Rotate a Vector2.
        /// </summary>
        /// <param name="point">Vector to rotate.</param>
        /// <param name="angle">Angle to rotate.</param>
        /// <returns>The result of rotating point.</returns>
        public static Vector2 Rotate(this Vector2 point, Quaternion angle) {
            Vector3 point3 = new Vector3(point.x, 0, point.y);
            point3 = angle * point3;

            return new Vector2(point3.x, point3.z);
        }

        /// <summary>
        /// Rotate around a given point.
        /// </summary>
        /// <param name="point">Point to rotate.</param>
        /// <param name="origin">Reference for rotation.</param>
        /// <param name="angle">Angle to rotate.</param>
        /// <returns>The result of rotating point around origin.</returns>
        public static Vector2 RotateAround(this Vector2 point, Vector2 origin, Quaternion angle) {
            Vector3 point3 = new Vector3(point.x, 0, point.y);
            Vector3 origin3 = new Vector3(origin.x, 0, origin.y);
            point3 = angle * (point3 - origin3) + origin3;

            return new Vector2(point3.x, point3.z);
        }

        /// <summary>
        /// Calculate two vector's dot product. Sugar for <see cref="Vector2.Dot(Vector2, Vector2)"/>
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns>The vector's dot product.</returns>
        public static float Dot(this Vector2 v, Vector2 u) {
            return Vector2.Dot(v, u);
        }

        #endregion


        public static Vector2 WithX(this Vector2 vec, float x) {
            return new Vector2(x, vec.y);
        }

        public static Vector2 WithY(this Vector2 vec, float y) {
            return new Vector2(vec.x, y);
        }


        public static Vector2 AddX(this Vector2 vec, float x) {
            return new Vector2(vec.x + x, vec.y);
        }

        public static Vector2 AddY(this Vector2 vec, float y) {
            return new Vector2(vec.x, vec.y + y);
        }


        public static Vector2 InvertX(this Vector2 vec) {
            return new Vector2(-vec.x, vec.y);
        }

        public static Vector2 InvertY(this Vector2 vec) {
            return new Vector2(vec.x, -vec.y);
        }

        public static Vector2 Invert(this Vector2 vec) {
            return new Vector2(-vec.x, -vec.y);
        }

        /// <summary>
        /// Get vector between source and destination
        /// </summary>
        public static Vector2 To(this Vector2 source, Vector2 destination) =>
            destination - source;
    }
}
#endif