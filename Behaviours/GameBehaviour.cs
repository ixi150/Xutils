using System;
using UnityEngine;

public abstract class GameBehaviour : MonoBehaviour
{
    protected static readonly YieldInstruction waitForEndOfFrame = new WaitForEndOfFrame();
    protected static readonly YieldInstruction waitForFixedUpdate = new WaitForFixedUpdate();

    Transform cachedTransform;
    GameObject cachedGameObject;

    public Transform CachedTransform => cachedTransform;
    public GameObject CachedGameObject => cachedGameObject;

    public Vector3 Position
    {
        get => CachedTransform.position;
        set => CachedTransform.position = value;
    }

    public Vector3 LocalPosition
    {
        get => CachedTransform.localPosition;
        set => CachedTransform.localPosition = value;
    }

    public Vector3 Forward
    {
        get => CachedTransform.forward;
        set => CachedTransform.forward = value;
    }

    public void Activate()
    {
        cachedGameObject.SetActive(true);
    }

    public void Activate(float delay)
    {
        Invoke(Activate, delay);
    }

    public void Deactivate()
    {
        cachedGameObject.SetActive(false);
        CancelInvoke();
        StopAllCoroutines();
    }

    public void Deactivate(float delay)
    {
        Invoke(Deactivate, delay);
    }

    protected static void EmptyAction()
    {
    }

    protected virtual void Awake()
    {
        cachedTransform = transform;
        cachedGameObject = gameObject;
    }

    protected void ForEachChild(Action<Transform> actionOnChild)
    {
        CachedTransform.ForEachChild(actionOnChild);
    }

    protected new void Invoke(string action, float delay)
    {
        throw new Exception("Use Invoke(Action action, float delay) instead");
    }

    protected new void InvokeRepeating(string action, float delay, float repeatRate)
    {
        throw new Exception("Use InvokeRepeating(Action action, float delay, float repeatRate) instead");
    }

    protected void Invoke(Action action, float delay)
    {
        base.Invoke(action.Method.Name, delay);
    }

    protected void InvokeRepeating(Action action, float delay, float repeatRate)
    {
        base.InvokeRepeating(action.Method.Name, delay, repeatRate);
    }

    protected void GetComponent<T>(out T component) where T : Component
    {
        component = GetComponent<T>();
    }

    protected void GetComponentIfNull<T>(ref T component) where T : Component
    {
        if (component == null)
            GetComponent(out component);
    }
}