using UnityEngine;
using System.Collections;

public class PrefabInitializer : MonoBehaviour
{
    public GameObject prefab;

	
	void Update ()
    {
	    if (prefab)
        {
            initialize();
            Destroy(this);
        }
	}

    void initialize()
    {
        Utils.Instantiate(prefab, transform);
    }

}
