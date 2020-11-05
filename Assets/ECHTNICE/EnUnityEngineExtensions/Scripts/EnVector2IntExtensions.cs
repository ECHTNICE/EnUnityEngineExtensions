#if !(DISABLE_ALL_EN_EXTENSIONS || DISABLE_EN_VECTOR2_EXTENSIONS || DISABLE_EN_VECTOR2INT_EXTENSIONS)

namespace UnityEngine {
    public static class EnVector2IntExtensions {

        public static Vector2Int WithX(this Vector2Int vec, int x) {
            return new Vector2Int(x, vec.y);
        }

        public static Vector2Int WithY(this Vector2Int vec, int y) {
            return new Vector2Int(vec.x, y);
        }

        public static Vector2Int AddX(this Vector2Int vec, int x) {
            return new Vector2Int(vec.x + x, vec.y);
        }

        public static Vector2Int AddY(this Vector2Int vec, int y) {
            return new Vector2Int(vec.x, vec.y + y);
        }


        public static Vector2Int InvertX(this Vector2Int vec) {
            return new Vector2Int(-vec.x, vec.y);
        }

        public static Vector2Int InvertY(this Vector2Int vec) {
            return new Vector2Int(vec.x, -vec.y);
        }

        public static Vector2Int Invert(this Vector2Int vec) {
            return new Vector2Int(-vec.x, -vec.y);
        }

        public static Vector3 ToVector3(this Vector2Int v) {
            return new Vector3(v.x, v.y);
        }

        public static Vector2 ToVector2(this Vector2Int v) {
            return new Vector2(v.x, v.y);
        }

    }
}
#endif