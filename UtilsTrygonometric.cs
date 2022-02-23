using UnityEngine;

public static partial class Utils
{
    public static float VectorToDegrees(Vector2 vector)
    {
        return 180f * VectorToRadians(vector) / Mathf.PI;
    }

    public static float VectorToRadians(Vector2 vector)
    {
        float rad = Mathf.Atan2(vector.x, vector.y);
        if (rad < 0f) rad += (2f * Mathf.PI);
        return rad;
    }

    public static Vector2 RotateVectorBy90Clockwise(Vector2 vector)
    {
        return new Vector2(vector.y, -vector.x);
    }

    public static Vector2 DegreesToVector(float degrees, float lenght = 1)
    {
        return RadiansToVector(degrees * Mathf.PI / 180f, lenght);
    }

    public static Vector2 RadiansToVector(float rad, float lenght = 1f)
    {
        rad *= -1f;
        while (rad < 0f) rad += (2f * Mathf.PI);
        return lenght * new Vector2(Mathf.Sin(rad), Mathf.Cos(rad));
    }
}