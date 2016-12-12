using UnityEngine;
using System.Collections;

public class Collector
{
    static Transform _all;
    public static Transform all
    {
        get
        {
            if (!_all) _all = createCollector("#Collector#");
            return _all;
        }
    }

    static Transform _enemies;
    public static Transform enemies
    {
        get
        {
            if (!_enemies) _enemies = createCollector("Enemies", all);
            return _enemies;
        }
    }

    static Transform _projectiles;
    public static Transform projectiles
    {
        get
        {
            if (!_projectiles) _projectiles = createCollector("Projectiles", all);
            return _projectiles;
        }
    }

    static Transform _particles;
    public static Transform particles
    {
        get
        {
            if (!_particles) _particles = createCollector("Particles", all);
            return _particles;
        }
    }

    static Transform _texts;
    public static Transform texts
    {
        get
        {
            if (!_texts) _texts = createCollector("Texts", all);
            return _texts;
        }
    }

    static Transform _dmg;
    public static Transform dmg
    {
        get
        {
            if (!_dmg) _dmg = createCollector("DMG", texts);
            return _dmg;
        }
    }

    static Transform _gems;
    public static Transform gems
    {
        get
        {
            if (!_gems) _gems = createCollector("Gems", all);
            return _gems;
        }
    }

    static Transform _managers;
    public static Transform managers
    {
        get
        {
            if (!_managers) _managers = createCollector("Managers", all);
            return _managers;
        }
    }

    ////////////////////////////////////////////////////////////////////
    static Transform createCollector(string name, Transform parent=null)
    {
        GameObject g = new GameObject();
        g.name = name;
        Transform t = g.transform;
        t.SetParent(parent);
        return t;
    }
}
