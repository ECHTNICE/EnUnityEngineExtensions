#if !(DISABLE_ALL_EN_EXTENSIONS || DISABLE_EN_PHYSICS_EXTENSIONS)

namespace UnityEngine {
    using System.Collections.Generic;

    /// <summary>
    /// Utility extensions for manipulating and working with Physics.
    /// 
    /// <example>
    /// <code>
    /// </code>
    /// </example>
    ///
    /// <example>
    /// <code>
    /// 
    /// #define DISABLE_ALL_EN_EXTENSIONS //Disable all Extensions
    /// #define DISABLE_EN_PHYSICS_EXTENSIONS // Disable this Extensions
    /// 
    /// </code>
    /// </example>
    /// </summary>
    public static class EnPhysicsExtensions {

        /// <summary>
        /// ConeCastAll extension method for the Physics
        /// </summary>
        /// <param name="physics"></param>
        /// <param name="origin"></param>
        /// <param name="maxRadius"></param>
        /// <param name="direction"></param>
        /// <param name="maxDistance"></param>
        /// <param name="coneAngle"></param>
        /// <param name="layerMask"></param>
        /// <param name="queryTriggerInteraction"></param>
        /// <returns></returns>
        public static RaycastHit[] ConeCastAll(this Physics physics, 
            Vector3 origin, 
            float maxRadius, 
            Vector3 direction, 
            float maxDistance, 
            float coneAngle, 
            int layerMask = ~0,
            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal) {

            RaycastHit[] sphereCastHits = Physics.SphereCastAll(origin - new Vector3(0, 0, maxRadius), maxRadius, direction, maxDistance, layerMask, queryTriggerInteraction);
            List<RaycastHit> coneCastHitList = new List<RaycastHit>();

            if (sphereCastHits.Length > 0) {
                for (int i = 0; i < sphereCastHits.Length; i++) {
                    Vector3 hitPoint = sphereCastHits[i].point;
                    Vector3 directionToHit = hitPoint - origin;
                    float angleToHit = Vector3.Angle(direction, directionToHit);

                    if (angleToHit < coneAngle) {
                        coneCastHitList.Add(sphereCastHits[i]);
                    }
                }
            }

            RaycastHit[] coneCastHits = new RaycastHit[coneCastHitList.Count];
            coneCastHits = coneCastHitList.ToArray();

            return coneCastHits;
        }
    }
}
#endif