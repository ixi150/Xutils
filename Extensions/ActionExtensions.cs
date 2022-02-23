using System;

public static class ActionExtensions
{
    public static void SafeInvoke(this Action action)
    {
        action?.Invoke();
    }

    public static void InvokeTimes(this Action action, int n)
    {
        Utils.For(n, action);
    }

    public static void InvokeTimes(this Action<int> action, int n)
    {
        Utils.For(n, action);
    }
}