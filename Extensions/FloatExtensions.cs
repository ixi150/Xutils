using UnityEngine;

public static class FloatExtensions
{
    public static float LimitedTo(this float f, float max)
    {
        return Mathf.Sign(f) * Mathf.Min(Mathf.Abs(f), max);
    }

    public static float Clamp(this float f, float min = 0f, float max = 1f)
    {
        if (f < min) f = min;
        if (f > max) f = max;
        return f;
    }

    public static float Sqr(this float f) => f * f;
}