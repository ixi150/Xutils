using UnityEngine;

namespace IXI
{
    public class ChildVisualizer : MonoBehaviour
    {
        [SerializeField] bool alwaysShow = true;
        [SerializeField] Color color = Color.white;

        void DrawGizmos()
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
                DrawGizmos();
        }

        void OnDrawGizmosSelected()
        {
            DrawGizmos();
        }
    }
}