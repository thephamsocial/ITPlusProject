using UnityEngine;

public class GunController : GunControllerBase
{

    void Update()
    {
        shootingTime -= Time.deltaTime;
        // Debug.Log(shootingTime);
    }
    public override void Fire()
    {
        if (shootingTime > 0) return;
        float angle = transform.eulerAngles.z;
        float angleToRadian = angle * Mathf.Deg2Rad;
        Vector2 dir = new Vector2(Mathf.Sin(-angleToRadian), Mathf.Cos(-angleToRadian));

        float rotateBullet = ((Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90f);


        GameObject getInstanceGunBullet = ObjectPooling.Instance.GetBulletPooling();
       
        if (getInstanceGunBullet == null)
        {
            BulletBase _bullet = Instantiate<BulletBase>(bullet, transform.position, Quaternion.identity);
            _bullet.Init(speed, lifeTime, damage, dir, rotateBullet);

            ObjectPooling.Instance.AddBullet(_bullet.gameObject);
        }
        else
        {
            getInstanceGunBullet.GetComponent<BulletBase>().Init(speed, lifeTime, damage, dir, rotateBullet);
            getInstanceGunBullet.transform.position = transform.position;
            getInstanceGunBullet.gameObject.SetActive(true);
        }
           
        shootingTime = maxShootingTime;
    }
}
