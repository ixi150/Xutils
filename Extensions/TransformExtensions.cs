using System;
using UnityEngine;

public static class TransformExtensions
{
    public static void ModifyPosition(this Transform transform,
        float x = float.NaN,
        float y = float.NaN,
        float z = float.NaN)
    {
        transform.position = transform.position.Modified(x, y, z);
    }

    public static void ModifyLocalPosition(this Transform transform,
        float x = float.NaN,
        float y = float.NaN,
        float z = float.NaN)
    {
        transform.localPosition = transform.localPosition.Modified(x, y, z);
    }

    public static void ModifyLocalScale(this Transform transform,
        float x = float.NaN,
        float y = float.NaN,
        float z = float.NaN)
    {
        transform.localScale = transform.localScale.Modified(x, y, z);
    }

    public static void ResetAll(this Transform transform)
    {
        transform.ResetPosition();
        transform.ResetRotation();
        transform.ResetScale();
    }

    public static void ResetPosition(this Transform transform)
    {
        transform.localPosition = Vector3.zero;
    }

    public static void ResetRotation(this Transform transform)
    {
        transform.localRotation = Quaternion.identity;
    }

    public static void ResetScale(this Transform transform)
    {
        transform.localScale = Vector3.one;
    }

    public static Transform GetFirstChild(this Transform t)
    {
        return t.GetChild(0);
    }

    public static Transform GetLastChild(this Transform t)
    {
        return t.GetChild(t.childCount - 1);
    }

    public static void ForEachChild(this Transform transform, Action<Transform> actionOnChild)
    {
        if (actionOnChild == null) return;
        foreach (Transform child in transform)
        {
            actionOnChild.Invoke(child);
        }
    }

    public static Transform CreateChild(string name, Transform parent)
    {
        Transform child = new GameObject(name).transform;
        child.parent = parent;
        child.localPosition = Vector2.zero;
        child.localRotation = new Quaternion();
        child.localScale = Vector3.one;
        return child;
    }

    public static void DestroyAllChildren(this Transform parent)
    {
        if (parent == null) return;
        while (parent.childCount > 0)
            GameObject.Destroy(parent.GetChild(0).gameObject);
    }
}