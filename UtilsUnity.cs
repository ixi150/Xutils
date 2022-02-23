using UnityEngine;
using System.Collections;
using System.Linq;

public static partial class Utils
{
    public static Collider2D FindCollider2D(GameObject go, bool isTrigger)
    {
        if (!go) return null;
        return go.GetComponents<Collider2D>()
                 .FirstOrDefault(c => c.isTrigger == isTrigger);
    }

    public static Collider FindCollider(GameObject go, bool isTrigger)
    {
        if (!go) return null;
        return go.GetComponents<Collider>()
                 .FirstOrDefault(c => c.isTrigger == isTrigger);
    }

    public static Color SetColorAlfa(ref Color color, float alfa)
    {
        color.a = alfa.Clamp();
        return color;
    }

    public static Color SetColorAlfa(this Color color, float alfa)
    {
        return SetColorAlfa(ref color, alfa);
    }

    public static GameObject Instantiate(GameObject prefab)
    {
        return Instantiate(prefab, Vector3.zero);
    }
    public static GameObject Instantiate(GameObject prefab, Vector3 position)
    {
        return Instantiate(prefab, position, new Quaternion());
    }
    public static GameObject Instantiate(GameObject prefab, Vector3 position, Vector3 rotation)
    {
        return Instantiate(prefab, position, Quaternion.Euler(rotation));
    }
    public static GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        return GameObject.Instantiate(prefab, position, rotation) as GameObject;
    }
    public static GameObject Instantiate(GameObject prefab, Transform parent)
    {
        if (!prefab) return null;
        GameObject go = Instantiate(prefab);
        Transform t = go.transform;
        Vector3 scale = t.localScale;
        t.parent = parent;
        t.localPosition = Vector2.zero;
        t.localRotation = new Quaternion();
        t.localScale = scale;
        return go;
    }

    public static string GetMethodName(System.Action method)
    {
        return method.Method.Name;
    }
}