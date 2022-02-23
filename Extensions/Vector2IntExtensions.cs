using UnityEngine;

namespace Xunity.Extensions
{
    public static class Vector2IntExtensions
    {
        public static Vector2Int Modified(this Vector2Int vector, int? x = null, int? y = null)
        {
            if (x.HasValue) vector.x = x.Value;
            if (y.HasValue) vector.y = y.Value;
            return vector;
        }

        public static Vector2Int Multiply(this Vector2Int a, Vector2Int b)
        {
            a.Scale(b);
            return a;
        }

        public static Vector2 ToVector2(this Vector2Int v)
        {
            return new Vector2(v.x, v.y);
        }

        public static bool IsLongerThan(this Vector2Int vector, int lenght) => vector.sqrMagnitude > lenght.Sqr();
        public static bool IsLongerThan(this Vector2Int v1, Vector2Int v2) => v1.sqrMagnitude > v2.sqrMagnitude;
        public static bool IsShorterThan(this Vector2Int vector, int lenght) => vector.sqrMagnitude < lenght.Sqr();
        public static bool IsShorterThan(this Vector2Int v1, Vector2Int v2) => v1.sqrMagnitude < v2.sqrMagnitude;
    }
}