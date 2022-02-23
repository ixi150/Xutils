using UnityEngine;

namespace IXI
{
    [RequireComponent(typeof(Camera))]
    public class CameraBlit : MonoBehaviour
    {
        [SerializeField] Material material;
    
        void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            Graphics.Blit(src, dest, material);
        }
    }
}
