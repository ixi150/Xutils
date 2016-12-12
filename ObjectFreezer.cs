using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(CircleCollider2D))]
public class ObjectFreezer : MonoBehaviour
{
    Transform frozen, frozenParent;
    bool isFrozen=false;

    static float radiusSqr = 15*15;

    static bool @shouldFreeze;
    static float @distanceSqr;
    static Vector2 @pos;
    //new CircleCollider2D collider;

    void Start ()
    {
        frozen = transform.parent;
        frozenParent = frozen.parent;
        if (!frozen)
        {
            Destroy(gameObject);
            return;
        }
        //collider = GetComponent<CircleCollider2D>();
        //collider.radius = radius;
        //collider.isTrigger = true;
	}
    void Update()
    {
        if (!frozen)
        {
            Destroy(gameObject);
            return;
        }
        if (MindPlayer.player1 || MindPlayer.player2)
        {
            @shouldFreeze = true;
            if (MindPlayer.player1)
                @shouldFreeze &= checkPlayer(MindPlayer.player1);
            if (MindPlayer.player2)
                @shouldFreeze &= checkPlayer(MindPlayer.player2);
            setFreeze(@shouldFreeze);
        }
    }

    bool checkPlayer(MindPlayer mind)
    {
        if (!mind || !mind.body || mind.body.HP.isUnderOrMin) return false;
        @pos = mind.body.bloodPoint ? mind.body.bloodPoint.position : mind.body.transform.position;
        @distanceSqr = (@pos - (Vector2)frozen.position).sqrMagnitude;
        return @distanceSqr > radiusSqr;
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.Player))
            destroyAndFree();
    }

    void destroyAndFree()
    {
        frozen.parent = transform.parent;
        frozen.gameObject.SetActive(true);
        Destroy(gameObject);
    }

    void setFreeze(bool freeze)
    {
        if (isFrozen == freeze) return;
        else isFrozen = freeze;

        if (freeze)
        {
            transform.parent = frozenParent;
            frozen.parent = transform;
        }
        else
        {
            frozen.parent = frozenParent;
            transform.parent = frozen;
        }
        frozen.gameObject.SetActive(!freeze);
    }
}
