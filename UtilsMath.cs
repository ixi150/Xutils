using UnityEngine;
using System.Collections;

public abstract partial class Utils
{
    public static bool isEven(int x)
    {
        return x % 2 == 0;
    }
    public static bool isOdd(int x)
    {
        return x % 2 == 1;
    }

    public static float clamp(float f, float min = 0, float max = 1)
    {
        return clamp(ref f, min, max);
    }

    public static int clamp(int f, int min = 0, int max = 1)
    {
        return clamp(ref f, min, max);
    }

    public static float clamp(ref float f, float min = 0, float max = 1)
    {
        if (f < min) f = min;
        if (f > max) f = max;
        return f;
    }

    public static int clamp(ref int f, int min = 0, int max = 1)
    {
        if (f < min) f = min;
        if (f > max) f = max;
        return f;
    }

    /// <summary>
    /// Randomizes output based on chance.
    /// </summary>
    /// <param name="luck">Chance 0-1. (0%-100%)</param>
    /// <returns>When 0 = always false;
    /// When 1 = always true;</returns>
    public static bool testLuck(float luck)
    {
        return Random.Range(0, 1f) < Mathf.Clamp01(luck);
    }

    public static bool cooldown(ref float timer)
    {
        timer = Mathf.Clamp(timer - Time.deltaTime, 0, timer);
        return timer == 0;
    }

    public static T[] resizeArray<T>(T[] array, int size, T defaultValue)
    {
        T[] temp = new T[size];
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = array.Length > i ? array[i] : defaultValue;
        }
        return temp;
    }

    public static T[] resizeArray<T>(ref T[] array, int size, T defaultValue)
    {
        array = resizeArray<T>(array, size, defaultValue);
        return array;
    }
}
