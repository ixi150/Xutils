using UnityEngine;

public static class Vector3Extensions
{
    public static Vector3 Modified(this Vector3 vector,
        float x = float.NaN,
        float y = float.NaN,
        float z = float.NaN)
    {
        if (!float.IsNaN(x)) vector.x = x;
        if (!float.IsNaN(y)) vector.y = y;
        if (!float.IsNaN(z)) vector.z = z;
        return vector;
    }

    public static Vector3 Multiply(this Vector3 a, Vector3 b)
    {
        a.Scale(b);
        return a;
    }

    public static Vector3 LimitedTo(this Vector3 v, Vector3 max)
    {
        v.x = v.x.LimitedTo(max.x);
        v.y = v.y.LimitedTo(max.y);
        v.z = v.z.LimitedTo(max.z);
        return v;
    }

    public static bool IsLongerThan(this Vector3 vector, float lenght) => vector.sqrMagnitude > lenght.Sqr();
    public static bool IsLongerThan(this Vector3 v1, Vector3 v2) => v1.sqrMagnitude > v2.sqrMagnitude;
    public static bool IsShorterThan(this Vector3 vector, float lenght) => vector.sqrMagnitude < lenght.Sqr();
    public static bool IsShorterThan(this Vector3 v1, Vector3 v2) => v1.sqrMagnitude < v2.sqrMagnitude;
}