using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[InitializeOnLoad]
public static class EditorHotkeysTracker
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
            GameObject clone;
            var transform = go.transform;
            GameObject prefabRoot = PrefabUtility.GetPrefabParent(go) as GameObject;
            var root = PrefabUtility.FindRootGameObjectWithSameParentPrefab(go);
            if (prefabRoot != null && go == root)
                clone = PrefabUtility.InstantiatePrefab(prefabRoot) as GameObject;
            else
                clone = Utils.Instantiate(go);

            clone.name = go.name;
            clone.transform.SetParent(transform.parent);
            clone.transform.position = transform.position;
            clone.transform.SetAsLastSibling();
            objectList.Add(clone);
        }
        Selection.objects = objectList.ToArray();
    }
}