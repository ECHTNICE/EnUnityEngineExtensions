#if !(DISABLE_ALL_EN_EXTENSIONS || DISABLE_EN_COMPONENT_EXTENSIONS)
namespace UnityEngine {
    using System;
    using System.Reflection;

    /// <summary>
    /// 
    /// </summary>
    public static class EnComponentExtensions {

        /// <summary>
        /// Has type Component.
        /// </summary>
        /// <param name="component"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool HasComponent(this Component component, Type type) {
            return component.GetComponent(type) != null;
        }

        /// <summary>
        /// Has T Component.
        /// </summary>
        /// <returns><c>true</c>, if component exist, <c>false</c> otherwise.</returns>
        /// <param name="self">Self.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static bool HasComponent<T>(this Component self) where T : Component {
            return self.gameObject.GetComponent<T>() != null;
        }

        /// <summary>
        /// Get T Component In Hierarchy Children or Parents
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="component"></param>
        /// <returns></returns>
        public static T GetComponentInHierarchy<T>(this Component component) {
            var candidate = component.GetComponentInChildren<T>();

            return candidate == null ? component.GetComponentInParent<T>() : candidate;
        }

        /// <summary>
        /// Get a Copy Of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="comp"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static T GetCopyOf<T>(this Component comp, T other) where T : Component {
            Type type = comp.GetType();
            if (type != other.GetType()) return null; // type mis-match
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
            PropertyInfo[] pinfos = type.GetProperties(flags);
            foreach (var pinfo in pinfos) {
                if (pinfo.CanWrite && pinfo.CanRead) {
                    try {
                        pinfo.SetValue(comp, pinfo.GetValue(other, null), null);
                    }
                    catch { } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
                }
            }
            FieldInfo[] finfos = type.GetFields(flags);
            foreach (var finfo in finfos) {
                finfo.SetValue(comp, finfo.GetValue(other));
            }
            return comp as T;
        }


        /// <summary>
        /// Get vector between source and target
        /// </summary>
        public static Vector3 To(this Component source, Component target) =>
            source.transform.position.To(target.transform.position);

        /// <summary>
        /// Get vector between source and target
        /// </summary>
        public static Vector3 To(this Component source, GameObject target) =>
            source.transform.position.To(target.transform.position);

    }
}
#endif