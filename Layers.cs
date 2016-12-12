using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class Layers
{
    const Layer L = null;

    public static Layer
        UI = L | "UI",
        Ground = L | "Ground",
        Player = L | "Player",
        PlayerGhost = L | "PlayerGhost",
        Background = L | "Background",
        Sight = L | "Sight",
        Enemy = L | "Enemy",
        Crowd = L | "Crowd",
        Clouds = L | "Clouds",
        HitBox = L | "HitBox",
        Misc = L | "Misc",
        Bound = L | "Bound",
        Platform = L | "Platform",
        Wall = L | "Wall",
        GroundCheck = L | "GroundCheck",
        Projectiles = L | "Projectiles",
        EnemyProjectiles = L | "Enemy Projectiles",
        Fog = L | "Fog",
        JumpDown = L | "JumpDown",
        Foreground = L | "Foreground";

    public static int GetMask(params Layer[] layers)
    {
        string[] s = new string[layers.Length];
        for (int i = 0; i < layers.Length; i++)
            s[i] = (string)layers[i];
        return LayerMask.GetMask(s);
    }

    public static int getUnpassableMask()
    {
        return GetMask(Bound, Wall, Ground);
    }

    public class Layer
    {
        

        public int id { get { return LayerMask.NameToLayer(s); } }

        string s;

        Layer(string s)
        {
            this.s = s;
        }

        public override string ToString()
        {
            return s;
        }

        public static explicit operator string(Layer o)
        {
            return o.s;
        }

        public static explicit operator int(Layer o)
        {
            return LayerMask.NameToLayer(o.s);
        }

        public static Layer operator | (Layer l, string s)
        {
            return new Layer(s);
        }

        public static bool operator == (Layer l, int i)
        {
            return i == (int)l;
        }

        public static bool operator != (Layer l, int i)
        {
            return i != (int)l;
        }

        public static bool operator ==(int i, Layer l)
        {
            return i == (int)l;
        }

        public static bool operator !=(int i, Layer l)
        {
            return i != (int)l;
        }

        public override bool Equals(object obj)
        {
            return this == obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
