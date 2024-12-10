using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public abstract class BulletBase: MonoBehaviour
{
    protected float speed, damage, lifeTime;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 dir = Vector2.zero;
   
    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Init(float speed, float lifeTime, float damage, Vector2 dir, float rotateBullet)
    {
        this.speed = speed;
        this.lifeTime = lifeTime;
        this.dir = dir;
        this.damage = damage;
        transform.rotation = Quaternion.Euler(0, 0, rotateBullet);
    }
    private void Update()
    {
        lifeTime -= Time.deltaTime;
        Debug.Log(lifeTime);
        if (lifeTime <= 0) Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = dir * speed;
    }
   
    protected abstract void BulletStatus(GameObject target);
   
}
