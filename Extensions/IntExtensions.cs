public static partial class IntExtensions
{
    public static bool IsEven(this int i)
    {
        return i % 2 == 0;
    }

    public static bool IsOdd(this int i)
    {
        return i % 2 == 1;
    }

    public static int Clamp(this int i, int min = 0, int max = 1)
    {
        if (i < min) i = min;
        if (i > max) i = max;
        return i;
    }

    public static int Sqr(this int i) => i * i;
}
