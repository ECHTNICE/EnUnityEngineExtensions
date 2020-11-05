#if !(DISABLE_ALL_EN_EXTENSIONS || DISABLE_EN_VECTOR3_EXTENSIONS || DISABLE_EN_VECTOR3INT_EXTENSIONS)

namespace UnityEngine {
    public static class EnVector3IntExtensions {

        public static Vector3Int WithX(this Vector3Int vec, int x) {
            return new Vector3Int(x, vec.y, vec.z);
        }

        public static Vector3Int WithY(this Vector3Int vec, int y) {
            return new Vector3Int(vec.x, y, vec.z);
        }

        public static Vector3Int WithZ(this Vector3Int vec, int z) {
            return new Vector3Int(vec.x, vec.y, z);
        }


        public static Vector3Int AddX(this Vector3Int vec, int x) {
            return new Vector3Int(vec.x + x, vec.y, vec.z);
        }

        public static Vector3Int AddY(this Vector3Int vec, int y) {
            return new Vector3Int(vec.x, vec.y + y, vec.z);
        }

        public static Vector3Int AddZ(this Vector3Int vec, int z) {
            return new Vector3Int(vec.x, vec.y, vec.z + z);
        }

        public static Vector3Int InvertX(this Vector3Int vec) {
            return new Vector3Int(-vec.x, vec.y, vec.z);
        }

        public static Vector3Int InvertY(this Vector3Int vec) {
            return new Vector3Int(vec.x, -vec.y, vec.z);
        }

        public static Vector3Int InvertZ(this Vector3Int vec) {
            return new Vector3Int(vec.x, vec.y, -vec.z);
        }

        public static Vector3Int Invert(this Vector3Int vec) {
            return new Vector3Int(-vec.x, -vec.y, -vec.z);
        }

        public static Vector2 ToVector2(this Vector3Int v) {
            return new Vector2(v.x, v.y);
        }

        public static Vector3 ToVector3(this Vector3Int v) {
            return new Vector3(v.x, v.y, v.z);
        }

    }
}
#endif