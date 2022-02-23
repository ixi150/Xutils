using System;
using UnityEngine;

public static partial class Utils
{
    /// <summary>
    /// Randomizes output based on chance.
    /// </summary>
    /// <param name="luck">Chance 0-1. (0%-100%)</param>
    /// <returns>When 0 = always false;
    /// When 1 = always true;</returns>
    public static bool TestLuck(float luck)
    {
        return UnityEngine.Random.Range(0, 1f) < Mathf.Clamp01(luck);
    }

    public static bool ProgressTimer(ref float timer)
    {
        timer = Mathf.Clamp(timer - Time.deltaTime, 0, timer);
        return timer == 0;
    }

    public static void ResizeArray<T>(ref T[] array, int size, T defaultValue = default(T))
    {
        array = array.ResizeArray(size, defaultValue);
    }

    public static void For(int n, Action a)
    {
        if (a == null) return;
        for (int i = 0; i < n; i++)
            a();
    }

    public static void For(int n, Action<int> a)
    {
        if (a == null) return;
        for (int i = 0; i < n; i++)
            a(i);
    }
}