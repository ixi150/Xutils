using UnityEngine;

namespace Xunity.Extensions
{
    public static class Vector3IntExtensions
    {
        public static Vector3Int Modified(this Vector3Int vector, int? x = null, int? y = null, int? z = null)
        {
            if (x.HasValue) vector.x = x.Value;
            if (y.HasValue) vector.y = y.Value;
            if (z.HasValue) vector.z = z.Value;
            return vector;
        }

        public static Vector3Int Multiply(this Vector3Int a, Vector3Int b)
        {
            a.Scale(b);
            return a;
        }

        public static Vector3 ToVector3(this Vector3Int v)
        {
            return new Vector3(v.x, v.y, v.z);
        }

        public static bool IsLongerThan(this Vector3Int vector, int lenght) => vector.sqrMagnitude > lenght.Sqr();
        public static bool IsLongerThan(this Vector3Int v1, Vector3Int v2) => v1.sqrMagnitude > v2.sqrMagnitude;
        public static bool IsShorterThan(this Vector3Int vector, int lenght) => vector.sqrMagnitude < lenght.Sqr();
        public static bool IsShorterThan(this Vector3Int v1, Vector3Int v2) => v1.sqrMagnitude < v2.sqrMagnitude;
    }
}