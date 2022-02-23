using UnityEngine;

namespace IXI
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        [SerializeField] bool destroyIfDuplicateTagInScene = false;

        void Awake()
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            if (destroyIfDuplicateTagInScene)
            {
                DestroyIfDuplicateTagInScene();
            }
        }

        void DestroyIfDuplicateTagInScene()
        {
            foreach (var go in GameObject.FindGameObjectsWithTag(tag))
            {
                if (!go.Equals(gameObject))
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}