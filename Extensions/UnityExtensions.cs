using System;
using UnityEngine;

public static class UnityExtensions
{
    public static void Invoke(this MonoBehaviour behaviour, Action method, float time)
    {
        behaviour.Invoke(method.Method.Name, time);
    }

    public static void SetParticleEnabled(this ParticleSystem ps, bool enabled)
    {
        if (ps)
        {
            ParticleSystem.EmissionModule em = ps.emission;
            em.enabled = enabled;
        }
    }
}