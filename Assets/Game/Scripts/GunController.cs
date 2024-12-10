using UnityEngine;

public class GunController : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private BulletBase bullet;
    [SerializeField] float speed, lifeTime, damage, maxShootingTime;
    private float shootingTime;
    public void Init(PlayerController playerController)
    {
        this.playerController = playerController;
        shootingTime = maxShootingTime;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shootingTime -= Time.deltaTime;
       // Debug.Log(shootingTime);
    }
    public void Fire()
    {
        if (shootingTime > 0) return;
        float angle = transform.eulerAngles.z;
        float angleToRadian = angle * Mathf.Deg2Rad;
        Vector2 dir = new Vector2(Mathf.Sin(-angleToRadian), Mathf.Cos(-angleToRadian));
        Debug.Log(dir);
        float rotateBullet = ((Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90f);
        Debug.Log(rotateBullet);
        Instantiate<BulletBase>(bullet, transform.position, Quaternion.identity).Init(speed, lifeTime, damage, dir, rotateBullet);
        shootingTime = maxShootingTime;

    }
    public void ChangeBullet(BulletBase bullet)
    {
        this.bullet = bullet;
    }
}
