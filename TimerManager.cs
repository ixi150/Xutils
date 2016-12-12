using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    void OnDestroy()
    {
        Timer.timers.Clear();
    }

    void Update()
    {
        int size = Timer.timers.Count;
        for (int i = 0; i < size; i++)
        {
            if (Timer.timers[i] != null)
                Timer.timers[i].update();
            else
                Timer.timers.RemoveAt(i--);
        }
    }
}

[System.Serializable]
public class Timer
{
    public static List<Timer> timers = new List<Timer>();
    public bool repeat = false, enabled = true,
        randomTimer, randomCooldown;

    public float timer=0, cooldown=0, delta=0;

    public float percentDone { get { return cooldown == 0 ? 1 : 1 - timer / cooldown; } }

    public Timer()
    {
        timers.Add(this);
    }

    public Timer(float time) : this()
    {
        cooldown = time;
    }

    ~Timer()
    {
        timers.Remove(this);
    }

    public void update()
    {
        if (enabled && Utils.cooldown(ref timer) && repeat)
            reset();
    }

    public void reset()
    {
        reset(randomTimer, randomCooldown);
    }

    public void reset(bool randomTimer, bool randomCooldown=false)
    {
        float cooldown = this.cooldown;
        if (randomCooldown)
            cooldown *= Random.Range(1 - delta, 1 + delta);
        if (randomTimer)
            timer = Random.Range(0, cooldown);
        else
            timer = cooldown;
    }

    public static bool operator >(Timer p, Timer f) { return p.timer > f.timer; }
    public static bool operator <(Timer p, Timer f) { return p.timer < f.timer; }
    public static bool operator >=(Timer p, Timer f) { return p.timer >= f.timer; }
    public static bool operator <=(Timer p, Timer f) { return p.timer <= f.timer; }

    public static bool operator >(Timer p, float f){ return p.timer > f; }
    public static bool operator <(Timer p, float f) { return p.timer < f; }
    public static bool operator >=(Timer p, float f) { return p.timer >= f; }
    public static bool operator <=(Timer p, float f) { return p.timer <= f; }
    public static bool operator ==(Timer p, float f) { return p.timer == f; }
    public static bool operator !=(Timer p, float f) { return p.timer != f; }

    public static bool operator >(float f, Timer p) { return p.timer < f; }
    public static bool operator <(float f, Timer p) { return p.timer > f; }
    public static bool operator >=(float f, Timer p) { return p.timer <= f; }
    public static bool operator <=(float f, Timer p) { return p.timer >= f; }
    public static bool operator ==(float f, Timer p) { return p.timer == f; }
    public static bool operator !=(float f, Timer p) { return p.timer != f; }
}

