using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace IXI
{
    [InitializeOnLoad]
    public static class EditorHotkeys
    {
        [MenuItem("GameObject/Duplicate without name incrementation %#d")] //left control + left shift + D
        static void DuplicateWithoutNameIncrementation()
        {
            var gos = Selection.objects;
            if (gos == null) return;

            List<Object> objectList = new List<Object>();
            for (int i = 0; i < gos.Length; i++)
            {
                var go = gos[i] as GameObject;
                if (go == null || go.IsPrefab()) continue;

                GameObject clone;
                var transform = go.transform;
                GameObject prefabRoot = PrefabUtility.GetCorrespondingObjectFromSource(go);
                var root = PrefabUtility.GetOutermostPrefabInstanceRoot(go);
                clone = prefabRoot != null && go == root 
                    ? PrefabUtility.InstantiatePrefab(prefabRoot) as GameObject 
                    : Utils.Instantiate(go);

                clone.name = go.name;
                clone.transform.SetParent(transform.parent);
                clone.transform.position = transform.position;
                clone.transform.SetAsLastSibling();
                objectList.Add(clone);
            }

            Selection.objects = objectList.ToArray();
        }

        public static bool IsPrefab(this GameObject go)
        {
            return go.scene.rootCount == 0;
        }
    }
}