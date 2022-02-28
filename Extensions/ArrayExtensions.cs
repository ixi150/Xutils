using UnityEngine;

public static class ArrayExtensions
{
    public static T GetRandomElement<T>(this T[] array)
    {
        return array[Random.Range(0, array.Length - 1)];
    }

	public static bool IsNullOrEmpty<T>(this T[] array)
	{
		return array == null || array.Length == 0;
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
