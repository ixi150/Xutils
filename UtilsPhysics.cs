using UnityEngine;
using System.Collections;

public abstract partial class Utils
{
    public static float calcJumpforce(Vector2 from, Vector2 to, float xSpeed, Rigidbody2D rb=null)
    {
        float t = Mathf.Abs(to.x - from.x) / xSpeed;
        float s = to.y - from.y;
        float force = -Physics2D.gravity.y * t * .5f + s/t;
        if (rb)
            force *= rb.gravityScale;
        return force;
    }

    public delegate void func();
    public delegate void funci(int i);
    public static void For(int n, func f)
    {
        for (int i = 0; i < n; i++)
            f();
    }
    public static void For(int n, funci f)
    {
        for (int i = 0; i < n; i++)
            f(i);
    }
}
