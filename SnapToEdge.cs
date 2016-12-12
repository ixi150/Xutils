using UnityEngine;
using System.Collections;

public class SnapToEdge : MonoBehaviour
{
    public enum Direction
    {
        top,bot,left,right
    }
    public Direction direction;
    public bool continual = true;
    public float offset = 0;
	
	void Update ()
    {
        switch (direction)
        {
            case Direction.bot:
            case Direction.top:
                break;

            case Direction.left:
                snapHorizontal(0, offset);
                break;
            case Direction.right:
                snapHorizontal(Screen.width, -offset);
                break;
        }

        if (!continual) Destroy(this);
	}

    void snapHorizontal(float screenPoint, float offset)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(screenPoint,0,0));
        pos.x += offset;
        pos.y = transform.position.y;
        pos.z = transform.position.z;

        transform.position = pos;
    }
}
