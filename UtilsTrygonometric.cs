using UnityEngine;
using System.Collections;

public abstract partial class Utils
{
    public class SineModule
    {
        public float Sin
        {
            get
            {
                calcIfNecessary();
                return _sin;
            }
        }

        float time, timer = 0;
        float _sin;
        float lastTime;

        public SineModule(float time)
        {
            if (time <= 0)
            {
                this.time = 1;
                Debug.LogError("Time can't be <= 0; time set to default = 1");
            }
            else
                this.time = time;
            lastTime = Time.time;
        }

        void calcIfNecessary()
        {
            if (lastTime != Time.time)
            {
                float deltaTime = Time.time - lastTime;
                lastTime = Time.time;
                timer += deltaTime;
                timer %= time;
                _sin = Mathf.Sin(2 * Mathf.PI * timer / time);
            }
        }
    }

    public static float vectorToDegrees(Vector2 vector)
    {
        return 180 * vectorToRadians(vector) / Mathf.PI;
    }

    public static float vectorToRadians(Vector2 vector)
    {
        float rad = Mathf.Atan2(vector.x, vector.y);
        if (rad < 0) rad += (2 * Mathf.PI);
        return rad;
    }

    public static Vector2 rotateVectorBy90Clockwise(Vector2 vector)
    {
        return new Vector2(vector.y, -vector.x);
    }

    public static Vector2 degreesToVector(float degrees, float lenght = 1)
    {
        return radiansToVector(degrees * Mathf.PI / 180, lenght);
    }

    public static Vector2 radiansToVector(float rad, float lenght = 1)
    {
        rad *= -1;
        while (rad < 0) rad += (2 * Mathf.PI);
        return lenght * new Vector2(Mathf.Sin(rad), Mathf.Cos(rad));
    }
    
}

