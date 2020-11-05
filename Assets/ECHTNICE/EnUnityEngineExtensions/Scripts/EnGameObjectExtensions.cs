#if !(DISABLE_ALL_EN_EXTENSIONS || DISABLE_EN_GAMEOBJECT_EXTENSIONS)

namespace UnityEngine {
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    ///
    /// 
    /// </summary>
    public static class EnGameObjectExtensions {
        public static void SetParent(this GameObject gameObject, GameObject parent) {
            gameObject.transform.SetParent(parent.transform);
        }

        public static void SetParent(this GameObject gameObject, GameObject parent, bool worldPositionStays) {
            gameObject.transform.SetParent(parent.transform, worldPositionStays);
        }

        public static bool IsNull(this Object obj) {
            return ((object)obj) == null;
        }

        public static bool IsNotNull(this Object obj) {
            return ((object)obj) != null;
        }

        public static void DestroyChildren(this GameObject inst) {
            if (inst == null)
                return;

            List<Transform> transforms = new List<Transform>();// inst.transform.childCount;
            int b = 0;
            foreach (Transform t in inst.transform) {
                transforms.Add(t);// = t;
                b++;
            }

            foreach (Transform t in transforms) {
                t.parent = null;
                Object.Destroy(t.gameObject);
            }

            transforms.Clear();
            transforms = null;
        }

        public static void ChangeLayersRecursively(this GameObject inst, string name) {
            if (inst == null)
                return;

            foreach (Transform child in inst.transform) {
                child.gameObject.layer = LayerMask.NameToLayer(name);
                ChangeLayersRecursively(child.gameObject, name);
            }
        }

        public static void SetLayerRecursively(this GameObject inst, int layer) {
            inst.layer = layer;
            foreach (Transform child in inst.transform)
                child.gameObject.SetLayerRecursively(layer);
        }

        /// <summary>
        /// Adds all the components found on a resource prefab.
        /// </summary>
        /// <param name='inst'>
        /// Instance of game object to add the components to
        /// </param>
        /// <param name='path'>
        /// Path of prefab relative to ANY resource folder in the assets directory
        /// </param>
        /// 
        public static void AddComponentsFromResource(this GameObject inst, string path) {
            var go = Resources.Load(path) as GameObject;

            foreach (var src in go.GetComponents<Component>()) {
                var dst = inst.AddComponent(src.GetType()) as Behaviour;
                dst.enabled = false;
                dst.GetCopyOf(src);
                dst.enabled = true;
            }
        }




        /// <summary>
        /// Adds a component of the specific type found on a resource prefab.
        /// </summary>
        /// <returns>
        /// The newly added component.
        /// </returns>
        /// <param name='inst'>
        /// Instance of game object to add the component to
        /// </param>
        /// <param name='path'>
        /// Path of prefab relative to ANY resource folder in the assets directory
        /// </param>
        /// <typeparam name='T'>
        /// The type of component to find on the prefab and add.
        /// </typeparam>
        /// <exception cref='ArgumentException'>
        /// Is thrown when the path is invalid.
        /// </exception>
        /// 
        public static T AddComponentFromResource<T>(this GameObject inst, string path)
            where T : Component {
            var go = Resources.Load(path) as GameObject;
            if (go == null)
                throw new ArgumentException("Invalid component path", "path");

            var src = go.GetComponent<T>();
            var dst = inst.AddComponent<T>();

            dst.GetCopyOf(src);

            return dst;
        }

        public static bool HasComponent<T>(this GameObject gameObject) {
            return gameObject.GetComponent<T>() != null;
        }

        public static bool HasComponent(this GameObject gameObject, Type type) {
            return gameObject.GetComponent(type) != null;
        }

        public static T GetComponentInHierarchy<T>(this GameObject gameObject) {
            var candidate = gameObject.GetComponentInParent<T>();

            return candidate == null ? gameObject.GetComponentInChildren<T>() : candidate;
        }




        /// <summary>
        /// Get vector between source and target
        /// </summary>
        public static Vector3 To(this GameObject source, Component target) =>
            source.transform.position.To(target.transform.position);

        /// <summary>
        /// Get vector between source and target
        /// </summary>
        public static Vector3 To(this GameObject source, GameObject target) =>
            source.transform.position.To(target.transform.position);




        public static void DumpRootTransforms() {
            Object[] objs = Object.FindObjectsOfType(typeof(GameObject));
            foreach (Object obj in objs) {
                GameObject go = obj as GameObject;
                if (go != null && go.transform.parent == null) {
                    DumpToLog(go);
                }
            }
        }

        public static void DumpToLog(GameObject go) {
            Debug.Log("DUMP: go:" + go.name + "::::" + DumpToString(go));
        }

        public static string DumpToString(GameObject go) {
            StringBuilder sb = new StringBuilder();
            sb.Append(go.name);
            DumpGameObject(go, sb, "", false);
            return sb.ToString();
        }

        private static void DumpGameObject(GameObject gameObject, StringBuilder sb, string indent, bool includeAllComponents) {
            bool rendererEnabled = false;
            var renderer = gameObject.GetComponent<Renderer>();
            if (renderer != null) {
                rendererEnabled = renderer.enabled;
            }

            int markerId = -1;
            bool hasLoadedObj = false;

            sb.Append(string.Format("\r\n{0}+{1} - a:{2} - r:{3} - mid:{4} - loadedObj: {5} - scale: x:{6} y:{7} z:{8} - pos: x:{9} y:{10} z:{11}",
                indent, gameObject.name,
                gameObject.activeSelf, rendererEnabled,
                markerId, hasLoadedObj,
                gameObject.transform.localScale.x,
                gameObject.transform.localScale.y,
                gameObject.transform.localScale.z,
                gameObject.transform.position.x,
                gameObject.transform.position.y,
                gameObject.transform.position.z));

            if (includeAllComponents) {
                foreach (Component component in gameObject.GetComponents<Component>()) {
                    DumpComponent(component, sb, indent + "  ");
                }
            }

            foreach (Transform child in gameObject.transform) {
                DumpGameObject(child.gameObject, sb, indent + "  ", includeAllComponents);
            }
        }

        private static void DumpComponent(Component component, StringBuilder sb, string indent) {
            sb.Append(string.Format("{0}{1}", indent, (component == null ? "(null)" : component.GetType().Name)));
        }

    }
}
#endif