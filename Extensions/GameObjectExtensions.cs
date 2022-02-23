using UnityEngine;

public static class GameObjectExtensions
{
    public static void Deactivate(this Component component)
    {
        component.gameObject.Deactivate();
    }

    public static void Deactivate(this GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public static void Activate(this Component component)
    {
        component.gameObject.Activate();
    }

    public static void Activate(this GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public static void DestroyAllChildren(this GameObject gameObject)
    {
        if (gameObject == null) return;
        gameObject.transform.DestroyAllChildren();
    }
}