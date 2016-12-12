using UnityEngine;
using System.Collections;

public abstract partial class Utils
{
    public static Collider2D findCollider(GameObject go, bool isTrigger)
    {
        if (!go) return null;
        foreach (Collider2D c in go.GetComponents<Collider2D>())
        {
            if (c.isTrigger == isTrigger) return c;
        }
        return null;
    }

    public static Color setColorAlfa(ref Color color, float alfa)
    {
        clamp(ref alfa);
        color.a = alfa;
        return color;
    }
    public static Color setColorAlfa(Color color, float alfa)
    {
        return setColorAlfa(ref color, alfa);
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
    public static Transform createChild(string name, Transform parent)
    {
        Transform child = new GameObject(name).transform;
        child.parent = parent;
        child.localPosition = Vector2.zero;
        child.localRotation = new Quaternion();
        child.localScale = Vector3.one;
        return child;
    }

	public static void ClearChildren(Transform parent){
		if (!parent)
			return;
		while(parent.childCount > 0)
			GameObject.DestroyImmediate(parent.GetChild(0).gameObject);
	}
    
    public static void Invoke(MonoBehaviour behaviour, System.Action method, float time)
    {
        behaviour.Invoke(method.Method.Name, time);
    }

    public static string GetFunctionName(System.Action method)
    {
        return method.Method.Name;
    }

    public static T GetComponentInParents<T>(Transform firstToLook)
    {
        System.Type type = typeof(T);
        Component component = null;
        while (firstToLook)
        {
            component = firstToLook.GetComponent(type);
            if (component) break;
            firstToLook = firstToLook.parent;
        }
        if (firstToLook)
            return firstToLook.GetComponent<T>();
        else
            return default(T);
    }

    public static void setPatricleSystemEnabled(ParticleSystem ps, bool enabled)
    {
        if (ps)
        {
            ParticleSystem.EmissionModule em = ps.emission;
            em.enabled = enabled;
        }
    }

    public static Vector4 getBoxColliderParams(BoxCollider2D box)
    {
        if (!box) return new Vector4();
        return new Vector4(box.offset.x, box.offset.y, box.size.x, box.size.y);
    }

    public static void setBoxColliderParams(BoxCollider2D box, Vector4 vector)
    {
        if (!box) return;
        box.offset = new Vector2(vector.x, vector.y);
        box.size = new Vector2(vector.z, vector.w);
    }
}

