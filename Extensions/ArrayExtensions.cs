using UnityEngine;

public static class ArrayExtensions
{
    public static T GetRandomElement<T>(this T[] container)
    {
        return container[Random.Range(0, container.Length - 1)];
    }

    public static T[] ResizeArray<T>(this T[] array, int size, T defaultValue = default(T))
    {
        T[] temp = new T[size];
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = array.Length > i ? array[i] : defaultValue;
        }
        return temp;
    }
}