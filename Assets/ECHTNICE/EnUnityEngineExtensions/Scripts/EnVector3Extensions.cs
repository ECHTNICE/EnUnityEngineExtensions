#if !(DISABLE_ALL_EN_EXTENSIONS || DISABLE_EN_VECTOR3_EXTENSIONS)

namespace UnityEngine
{
    using System.Collections.Generic;

    /// <summary>
    /// Unity Vector3 Extensions.
    ///
    /// <example>
    /// <code>
    /// 
    /// #define DISABLE_ALL_EN_EXTENSIONS //Disable all Extensions
    /// #define DISABLE_EN_VECTOR3_EXTENSIONS // Disable Vector3 Extensions
    /// 
    /// </code>
    /// </example>
    /// 
    /// <example>
    /// <code>
    /// var myPosition = this.transform.position;
    /// var closestEnemyPosition = myPosition.GetClosest(enemyPositions);
    /// </code>
    /// </example>
    /// </summary>
    public static class EnVector3Extensions {



		#region Set X/Y/Z

		// Set X

		public static Vector3 SetX(this Vector3 vector, float x) {
			return new Vector3(x, vector.y, vector.z);
		}

		public static Vector2 SetX(this Vector2 vector, float x) {
			return new Vector2(x, vector.y);
		}

		public static void SetX(this Transform transform, float x) {
			transform.position = transform.position.SetX(x);
		}

		// Set Y

		public static Vector3 SetY(this Vector3 vector, float y) {
			return new Vector3(vector.x, y, vector.z);
		}

		public static Vector2 SetY(this Vector2 vector, float y) {
			return new Vector2(vector.x, y);
		}

		public static void SetY(this Transform transform, float y) {
			transform.position = transform.position.SetY(y);
		}

		// Set Z

		public static Vector3 SetZ(this Vector3 vector, float z) {
			return new Vector3(vector.x, vector.y, z);
		}

		public static void SetZ(this Transform transform, float z) {
			transform.position = transform.position.SetZ(z);
		}

		// Set XY

		public static Vector3 SetXY(this Vector3 vector, float x, float y) {
			return new Vector3(x, y, vector.z);
		}

		public static void SetXY(this Transform transform, float x, float y) {
			transform.position = transform.position.SetXY(x, y);
		}

		// Set XZ

		public static Vector3 SetXZ(this Vector3 vector, float x, float z) {
			return new Vector3(x, vector.y, z);
		}

		public static void SetXZ(this Transform transform, float x, float z) {
			transform.position = transform.position.SetXZ(x, z);
		}

		// Set YZ

		public static Vector3 SetYZ(this Vector3 vector, float y, float z) {
			return new Vector3(vector.x, y, z);
		}

		public static void SetYZ(this Transform transform, float y, float z) {
			transform.position = transform.position.SetYZ(y, z);
		}

		//Reset

		/// <summary>
		/// Set position to Vector3.zero.
		/// </summary>
		public static void ResetPosition(this Transform transform) {
			transform.position = Vector3.zero;
		}


		// RectTransform 

		public static void SetPositionX(this RectTransform transform, float x) {
			transform.anchoredPosition = transform.anchoredPosition.SetX(x);
		}

		public static void SetPositionY(this RectTransform transform, float y) {
			transform.anchoredPosition = transform.anchoredPosition.SetY(y);
		}

		public static void OffsetPositionX(this RectTransform transform, float x) {
			transform.anchoredPosition = transform.anchoredPosition.OffsetX(x);
		}

		public static void OffsetPositionY(this RectTransform transform, float y) {
			transform.anchoredPosition = transform.anchoredPosition.OffsetY(y);
		}

		#endregion


		#region Offset X/Y/Z

		public static Vector3 Offset(this Vector3 vector, Vector2 offset) {
			return new Vector3(vector.x + offset.x, vector.y + offset.y, vector.z);
		}


		public static Vector3 OffsetX(this Vector3 vector, float x) {
			return new Vector3(vector.x + x, vector.y, vector.z);
		}

		public static Vector2 OffsetX(this Vector2 vector, float x) {
			return new Vector2(vector.x + x, vector.y);
		}

		public static void OffsetX(this Transform transform, float x) {
			transform.position = transform.position.OffsetX(x);
		}


		public static Vector2 OffsetY(this Vector2 vector, float y) {
			return new Vector2(vector.x, vector.y + y);
		}

		public static Vector3 OffsetY(this Vector3 vector, float y) {
			return new Vector3(vector.x, vector.y + y, vector.z);
		}

		public static void OffsetY(this Transform transform, float y) {
			transform.position = transform.position.OffsetY(y);
		}


		public static Vector3 OffsetZ(this Vector3 vector, float z) {
			return new Vector3(vector.x, vector.y, vector.z + z);
		}

		public static void OffsetZ(this Transform transform, float z) {
			transform.position = transform.position.OffsetZ(z);
		}


		public static Vector3 OffsetXY(this Vector3 vector, float x, float y) {
			return new Vector3(vector.x + x, vector.y + y, vector.z);
		}

		public static void OffsetXY(this Transform transform, float x, float y) {
			transform.position = transform.position.OffsetXY(x, y);
		}

		public static Vector2 OffsetXY(this Vector2 vector, float x, float y) {
			return new Vector2(vector.x + x, vector.y + y);
		}


		public static Vector3 OffsetXZ(this Vector3 vector, float x, float z) {
			return new Vector3(vector.x + x, vector.y, vector.z + z);
		}

		public static void OffsetXZ(this Transform transform, float x, float z) {
			transform.position = transform.position.OffsetXZ(x, z);
		}


		public static Vector3 OffsetYZ(this Vector3 vector, float y, float z) {
			return new Vector3(vector.x, vector.y + y, vector.z + z);
		}

		public static void OffsetYZ(this Transform transform, float y, float z) {
			transform.position = transform.position.OffsetYZ(y, z);
		}

		#endregion


		#region Clamp X/Y

		public static Vector3 ClampX(this Vector3 vector, float min, float max) {
			return vector.SetX(Mathf.Clamp(vector.x, min, max));
		}

		public static Vector2 ClampX(this Vector2 vector, float min, float max) {
			return vector.SetX(Mathf.Clamp(vector.x, min, max));
		}

		public static void ClampX(this Transform transform, float min, float max) {
			transform.SetX(Mathf.Clamp(transform.position.x, min, max));
		}


		public static Vector3 ClampY(this Vector3 vector, float min, float max) {
			return vector.SetY(Mathf.Clamp(vector.x, min, max));
		}

		public static Vector2 ClampY(this Vector2 vector, float min, float max) {
			return vector.SetY(Mathf.Clamp(vector.x, min, max));
		}

		public static void ClampY(this Transform transform, float min, float max) {
			transform.SetY(Mathf.Clamp(transform.position.x, min, max));
		}

		#endregion


		#region Invert

		public static Vector2 InvertX(this Vector2 vector) {
			return new Vector2(-vector.x, vector.y);
		}

		public static Vector2 InvertY(this Vector2 vector) {
			return new Vector2(vector.x, -vector.y);
		}

		#endregion


		#region Convert

		public static Vector2 ToVector2(this Vector3 vector) {
			return new Vector2(vector.x, vector.y);
		}

		public static Vector3 ToVector3(this Vector2 vector) {
			return new Vector3(vector.x, vector.y);
		}


		public static Vector2 ToVector2(this Vector2Int vector) {
			return new Vector2(vector.x, vector.y);
		}

		public static Vector3 ToVector3(this Vector3Int vector) {
			return new Vector3(vector.x, vector.y);
		}


		public static Vector2Int ToVector2Int(this Vector2 vector) {
			return new Vector2Int(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y));
		}

		public static Vector3Int ToVector3Int(this Vector3 vector) {
			return new Vector3Int(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y), Mathf.RoundToInt(vector.z));
		}

		#endregion


        #region Approximately

		public static bool Approximately(this Vector3 vector, Vector3 compared, float threshold = 0.1f) {
			var xDiff = Mathf.Abs(vector.x - compared.x);
			var yDiff = Mathf.Abs(vector.y - compared.y);
			var zDiff = Mathf.Abs(vector.z - compared.z);

			return xDiff <= threshold && yDiff <= threshold && zDiff <= threshold;
		}

		public static bool Approximately(this Vector2 vector, Vector2 compared, float threshold = 0.1f) {
			var xDiff = Mathf.Abs(vector.x - compared.x);
			var yDiff = Mathf.Abs(vector.y - compared.y);

			return xDiff <= threshold && yDiff <= threshold;
		}

		#endregion


		#region Get Closest 

		/// <summary>
		/// Finds the position closest to the given one.
		/// </summary>
		/// <param name="position">World position.</param>
		/// <param name="otherPositions">Other world positions.</param>
		/// <returns>Closest position.</returns>
		public static Vector3 GetClosest(this Vector3 position, IEnumerable<Vector3> otherPositions) {
			var closest = Vector3.zero;
			var shortestDistance = Mathf.Infinity;

			foreach (var otherPosition in otherPositions) {
				var distance = (position - otherPosition).sqrMagnitude;

				if (distance < shortestDistance) {
					closest = otherPosition;
					shortestDistance = distance;
				}
			}

			return closest;
		}

		public static Vector3 GetClosest(this IEnumerable<Vector3> positions, Vector3 position) {
			return position.GetClosest(positions);
		}

		#endregion


		#region To

        /// <summary>
		/// Get vector between source and destination
		/// </summary>
		public static Vector3 To(this Vector3 source, Vector3 destination) =>
			destination - source;

		

		#endregion
	}
}

#endif