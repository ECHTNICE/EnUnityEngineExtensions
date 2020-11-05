#if !(DISABLE_ALL_EN_EXTENSIONS || DISABLE_EN_LAYERMASK_EXTENSIONS)
namespace UnityEngine
{
    /// <summary>
    /// Unity LayerMask extensions.
    /// 
    /// <example>
    /// <code>
    /// LayerMask myMask = oldMask.Default();
    /// myMask.ToEverything();
    /// </code>
    /// </example>
    /// 
    /// </summary>
    public static class EnLayerMaskExtensions
    {
        public static LayerMask MaskDefault = 0;
        public static LayerMask MaskTransparentFx = 1;
        public static LayerMask MaskEverything = ~0;
        //public static LayerMask MaskIgnoreRaycastLayer = Physics.IgnoreRaycastLayer;
        //public static LayerMask MaskDefaultRaycastLayers = Physics.DefaultRaycastLayers;

        public static LayerMask ToLayerMask(this LayerMask mask, int layer)
        {
            return 1 << layer;
        }

        public static bool LayerInMask(this LayerMask mask, int layer) {
            return ((1 << layer) & mask) != 0;
        }

        public static LayerMask Everything(this LayerMask mask) {
            return MaskEverything;
        }

        public static void ToEverything(this ref LayerMask mask) {
            mask=MaskEverything;
        }

        public static LayerMask Default(this LayerMask mask) {
            return MaskDefault;
        }

        public static void ToDefault(this ref LayerMask mask) {
            mask = MaskDefault;
        }

        public static LayerMask TransparentFx(this LayerMask mask) {
            return MaskTransparentFx;
        }

        public static void ToTransparentFx(this ref LayerMask mask) {
            mask = MaskTransparentFx;
        }


    }
}
#endif