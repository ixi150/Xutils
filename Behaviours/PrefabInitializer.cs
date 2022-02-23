using UnityEngine;

namespace IXI
{
    public class PrefabInitializer : MonoBehaviour
    {
        [SerializeField] GameObject prefab;

        void Start()
        {
            if (prefab)
            {
                Utils.Instantiate(prefab, transform);
            }

            Destroy(this);
        }
    }
}
