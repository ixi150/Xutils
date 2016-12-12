using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unique : MonoBehaviour
{
    public enum Tag
    {
        Rewired, MenuManager, Speaker, Camera, MenuBG, EventSystem, Listener
    }

    public Tag ID;
    public bool shouldBeFree = false;

    static Dictionary<Tag, Unique> dictionary = new Dictionary<Tag, Unique>();

	void Awake()
    {
	    if (dictionary.ContainsKey(ID))
        {
            Destroy(gameObject);
        }
        else
        {
            dictionary.Add(ID, this);
        }

        if (shouldBeFree) transform.parent = null;
	}

    public static Unique get(Tag tag)
    {
        Unique u;
        if (dictionary.TryGetValue(tag, out u))
        {
            return u;
        }
        else
        {
            return null;
        }
    }

}
