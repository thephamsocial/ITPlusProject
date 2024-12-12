using UnityEngine;

public class EnemyController : MonoBehaviour, IGetHit
{
    [SerializeField] private Transform player;
    private Rigidbody2D rb;
    [SerializeField] private float hp;
    [SerializeField] private float armor;
    [SerializeField] private float speed;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerMask;

    public GameManager gameManager;
    Vector2 movement;
    Vector2 dir;
    public bool isChasing = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {

        ChasePlayer();
        DetectRayObs();
        DetectEverything();
        RotateToPlayer();

    }
    private void FixedUpdate()
    {
        if (isChasing) rb.linearVelocity = movement;
        else rb.linearVelocity = Vector2.zero;
    }
    private bool DetectRayObs()
    {
        if (player != null)
        {
            dir = player.position - transform.position;
            Color color = Color.red;
            Debug.DrawRay(transform.position, dir, color);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, dir.magnitude);
            Debug.Log(hit.collider.name);

            if (!hit.collider.CompareTag("Player")) return true;

        }
        return false;
    }
    private void DetectEverything()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);
        foreach (Collider2D col in collider)
        {
            if (col.GetInstanceID() == transform.GetInstanceID()) continue;

            player = col.transform;

            if (DetectRayObs())
            {
                isChasing = false;
            }
            else
            {
                float distance = Vector2.Distance(player.position, transform.position);
                if (distance > 2f) isChasing = true;
                else isChasing = false;
                //Debug.Log(distance);
            }
        }
        if (player == null) return;

        if ((player.position - transform.position).magnitude > radius)
        {
            player = null;
            isChasing = false;
        }
    }
    public void RotateToPlayer()
    {
        if (!isChasing) return;

        Vector3 dir = player.position - transform.position;
        float angle = ((Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 90f);
        Debug.LogError(angle);
        Quaternion rotation = transform.rotation;
        rotation.eulerAngles = new Vector3(0, 0, angle);
        transform.rotation = rotation;

    }
    private void ChasePlayer()
    {
        Debug.Log(player);
        if (player == null) return;
        movement = (player.position - transform.position).normalized;
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (!collision.CompareTag("Player")) return;
    //    player = collision.transform;
    //    isChasing = true;
    //}
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (!collision.CompareTag("Player")) return;
    //    player = collision.transform;
    //    isChasing = true;

    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (!collision.CompareTag("Player")) return;
    //    player = null;
    //    isChasing = false;

    //}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void GetHit(float damage)
    {

        if (hp <= 0)
        {
            return;
        } 
        if (damage - armor >= 0)
        {
            hp -= (damage - armor);
        }
        if (hp <= 0)
        {
            gameManager.kill++;
            Destroy(gameObject);
        }
       

        Debug.Log("hp" + hp);
        Debug.Log("damage" + damage);
        Debug.Log("armor" + armor);
       
    }
}
