using UnityEngine;
using System.Collections;

public class ChildShower : MonoBehaviour
{
    public bool alwaysShow = true;
    public Color color = Color.white;

    void drawGizmos()
    {
        Gizmos.color = color;
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.DrawLine(transform.position, transform.GetChild(i).position);
        };
    }

    void OnDrawGizmos()
    {
        if (alwaysShow)
            drawGizmos();
    }

    void OnDrawGizmosSelected()
    {
        drawGizmos();
    }
}
