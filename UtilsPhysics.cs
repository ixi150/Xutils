using UnityEngine;

public static partial class Utils
{
    public static float CalcVerticalForceForHorizontalJump2D(Vector2 from, Vector2 to, float horizontalSpeed, Rigidbody2D rb = null)
    {
        float t = Mathf.Abs(to.x - from.x) / horizontalSpeed;
        float s = to.y - from.y;
        float force = -Physics2D.gravity.y * t * .5f + s/t;
        if (rb)
        {
            force *= rb.gravityScale;
        }

        return force;
    }
}