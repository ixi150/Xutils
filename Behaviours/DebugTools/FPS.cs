using UnityEngine;

#if UNITY_EDITOR || DEVELOPMENT_BUILD
namespace IXI
{
    public class FPS : GameBehaviour
    {
        [SerializeField] Rect rect = new Rect(5, 5, 200, 50);
        [SerializeField] Color color = Color.white;

        string fps;
        int frames;

        void OnEnable()
        {
            InvokeRepeating(FetchFrames, 1, 1);
        }

        void OnDisable()
        {
            CancelInvoke();
        }

        void LateUpdate()
        {
            frames++;
        }

        void FetchFrames()
        {
            fps = "" + frames / 1f;
            frames = 0;
        }

        void OnGUI()
        {
            GUI.color = color;
            GUI.Label(rect, $"FPS: {fps}");
        }
    }
}
#endif