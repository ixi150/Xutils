using UnityEngine;

public static class Vector2Extensions
{
    public static Vector2 Modified(this Vector2 vector, float x = float.NaN, float y = float.NaN)
    {
        if (float.IsNaN(x)) vector.x = x;
        if (float.IsNaN(y)) vector.y = y;
        return vector;
    }

    public static Vector2 Multiply(this Vector2 a, Vector2 b)
    {
        a.Scale(b);
        return a;
    }

    public static Vector2 LimitedTo(this Vector2 v, Vector2 max)
    {
        v.x = v.x.LimitedTo(max.x);
        v.y = v.y.LimitedTo(max.y);
        return v;
    }

    public static bool IsLongerThan(this Vector2 vector, float lenght) => vector.sqrMagnitude > lenght.Sqr();
    public static bool IsLongerThan(this Vector2 v1, Vector2 v2) => v1.sqrMagnitude > v2.sqrMagnitude;
    public static bool IsShorterThan(this Vector2 vector, float lenght) => vector.sqrMagnitude < lenght.Sqr();
    public static bool IsShorterThan(this Vector2 v1, Vector2 v2) => v1.sqrMagnitude < v2.sqrMagnitude;
}