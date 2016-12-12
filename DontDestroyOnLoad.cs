using UnityEngine;
using System.Collections;

public class DontDestroyOnLoad : MonoBehaviour
{
    public bool destroyIfDuplicateTagInScene = true;

    void Awake()
    {
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
        if (destroyIfDuplicateTagInScene)
            DestroyIfDuplicateTagInScene();
    }

    void DestroyIfDuplicateTagInScene()
    {
        GameObject[] gameObjectsWithSameTag = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject go in gameObjectsWithSameTag)
        {
            if (!go.Equals(gameObject))
                Destroy(gameObject);
        }
    }
}
