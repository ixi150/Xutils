using System;

[Serializable]
public struct RangedFloat
{
    public float min;
    public float max;

    public float Random => UnityEngine.Random.Range(min, max);
}
