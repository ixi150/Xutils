using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CopyColor : MonoBehaviour 
{
    public SpriteRenderer from;
    public Image fromUIImage;

    [Header("Targets")]
    public Image toUIImage;
    public Text[] toUIText;
    public SpriteRenderer toRenderer;
    public TextMesh to;
    

    [Header("Settings")]
    public bool onlyAlfa = true;
    public bool continual = true;
    public bool inverted = false;

    float alfa;
    Color color;

    void Update () 
    {
        if (from == null && fromUIImage == null) return;

        if (onlyAlfa)
        {
            if (from)
                alfa = from.color.a;
            else
                alfa = fromUIImage.color.a;

            if (toRenderer != null)
                toRenderer.color = getColorWithAlfa(toRenderer.color);
            if (to != null)
                to.color = getColorWithAlfa(to.color);
            if (toUIImage != null)
                toUIImage.color = getColorWithAlfa(toUIImage.color);
            if (toUIText != null)
                foreach (Text text in toUIText)
                text.color = getColorWithAlfa(text.color);
        }
        else
        {
            if (from)
                color = from.color;
            else
                color = fromUIImage.color;
            alfa = color.a;

            if (to != null)
                to.color = getColorWithAlfa(color);
            if (toRenderer != null)
                toRenderer.color = getColorWithAlfa(color);
            if (toUIImage != null)
                toUIImage.color = getColorWithAlfa(color);
            if (toUIText != null)
                foreach (Text text in toUIText)
                    text.color = getColorWithAlfa(color);
        }

        /*Continue*/
        if (!continual)
            Destroy(this);
	}

    Color getColorWithAlfa(Color color)
    {
        color.a = inverted ? 1-alfa : alfa;
        return color;
    }
}
