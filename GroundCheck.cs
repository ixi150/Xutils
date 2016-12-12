using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour
{
    #region PublicVars
    public GameObject dustCloudPrefab;
    public GameObject dustParticlesPrefab;

    public bool grounded = false;
    public bool groundedPlatform = false;
    public bool groundedDust = false;
    public bool blocked = false;
    public LayerMask groundingLayers = 35651840; //pls dont ask
    public LayerMask jumpDownLayers = 33554432; //pls dont ask
    public LayerMask dustLayers = 256; //pls dont ask
    [HideInInspector]
    public Collider2D gr, grj, grd;

    public bool emitDust = true;
    public float yVelocityThreshold = 1;
    #endregion

    #region PrivateVars
    float jumpDownTime = .4f;
    BoxCollider2D boxCollider;
    Vector2 pointA, pointB;
    HeroController heroController;
    ParticleSystem ps;
    ParticleSystem.EmissionModule em;
    new Transform transform;
    Rigidbody2D rb;
    bool qualityIsGoodEnough { get { return QualitySettings.GetQualityLevel() > 0; } }
    Transform parent;
    Transform defaultParent;
    Timer dustTimer;
    #endregion



    #region UnityMethods
    void Awake()
    {
        transform = base.transform;
        heroController = GetComponentInParent<HeroController>();
        rb = GetComponentInParent<Rigidbody2D>();
        parent = transform.parent;

        /*Collider*/
        Collider2D collider = Utils.findCollider(gameObject, true);
        if (collider)
        {
            boxCollider = (BoxCollider2D)collider;
            pointA = boxCollider.offset - boxCollider.size / 2;
            pointB = boxCollider.offset + boxCollider.size / 2;
        }

        /*Dust*/
        if (!ps)
        {
            if (qualityIsGoodEnough)
            {
                ps = GetComponentInChildren<ParticleSystem>();
                if (!ps && dustParticlesPrefab)
                {
                    Utils.Instantiate(dustParticlesPrefab, transform);
                    ps = GetComponentInChildren<ParticleSystem>();
                }
                if (ps) em = ps.emission;
                if (dustCloudPrefab) dustTimer = new Timer(1);
            }
            else
            {
                dustCloudPrefab = dustParticlesPrefab = null;
            }
        }
        if (boxCollider)
            Destroy(boxCollider);
        //boxCollider.enabled = false;
    }

    void Start()
    {
        defaultParent = parent.parent;
    }

    void OnEnable()
    {
        if (ps)
        {
            var em = ps.emission;
            em.enabled = true;
        }
    }

    void OnDisable()
    {
        if (ps)
        {
            var em = ps.emission;
            em.enabled = false;
        }
    }

    void FixedUpdate2()
    {
        /*Grounding*/
        grj = null;
        if (rb.velocity.y < yVelocityThreshold)
            grj = CheckGrounding(jumpDownLayers);
        if (!grj)
            gr = CheckGrounding(groundingLayers);
        else
            gr = grj;
        grounded = gr;
        groundedPlatform = grj;

        /*Dust*/
        if (emitDust)
        {
            if (qualityIsGoodEnough)
                grd = CheckGrounding(dustLayers);
            else
                grd = null;
            if (dustCloudPrefab)
            {
                if (groundedDust != grd)
                    spawnDustCloud();
            }
            groundedDust = grd;
        }

        /*Elevator*/
        Transform newParent = defaultParent;
        if (grj && grj.tag == "Elevator")
        {
            newParent = grj.transform;
        }
        if (parent.parent != newParent)
            parent.parent = newParent;
    }

    public void Update()
    {
        if (ps) em.enabled = groundedDust && emitDust;
        if (!rb.IsSleeping())
            FixedUpdate2();
        //Awake();
    }
    #endregion

    public void tryJumpDown()
    {
        if (!grounded) return;
        if (groundedPlatform)
        {
            StartCoroutine(jumpingDown());
        }
    }

    IEnumerator jumpingDown()
    {
        setBlocked(true);
        yield return new WaitForSeconds(jumpDownTime);
        setBlocked(false);
    }

    void setBlocked(bool blocked)
    {
        if (heroController)
        {
            this.blocked = blocked;
            heroController.colliderPhysical.isTrigger = blocked;
        }
    }

    public Collider2D CheckGrounding(LayerMask layers)
    {
        return checkGrounding(layers);
        //Collider2D[] colliders = checkGrounding(layers);
        //if (colliders == null || colliders.Length <= 0)
        //    return false;
        //for (int i = 0; i < colliders.Length; i++)
        //{
        //    if (colliders[i] != null && !colliders[i].isTrigger)
        //        return true;
        //}
        //return false;
    }

    public Collider2D checkGrounding(LayerMask layers)
    {
        Vector2 a, b, p = (Vector2)base.transform.position;
        a = pointA;
        b = pointB;
        if (base.transform.lossyScale.x < 0)
        {
            a.x *= -1;
            b.x *= -1;
        }
        a += p;
        b += p;
        return Physics2D.OverlapArea(a, b, layers);
        //return Physics2D.OverlapAreaAll(a, b, layers);
    }

    void spawnDustCloud()
    {
        if (dustTimer.percentDone < 1) return;
        dustTimer.reset();
        Vector2 pos = ps ? ps.transform.position : transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.down, 1000, groundingLayers);
        if (hit) pos = hit.point;
        ParticleEffect.spawnEffect(dustCloudPrefab, pos);
    }
}
