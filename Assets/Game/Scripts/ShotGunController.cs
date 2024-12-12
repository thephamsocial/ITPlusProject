using UnityEngine;

public class ShotGunController : GunControllerBase
{
    [Space(50)]
    [Header("-------------Shot Gun Config--------------")]
    [SerializeField] private int numberBullet;
    [SerializeField] private int maxAngleFixed;
    [SerializeField] private float distanceBettweenBulletRandom;
    private GameObject getInstanceShotgunBullet = null;
    private void Update()
    {
        shootingTime -= Time.deltaTime;
    }
    public override void Fire()
    {
        if (shootingTime > 0) return;

        float rotation = transform.eulerAngles.z;
        float angleToRadian = rotation * Mathf.Deg2Rad;


        //nhu transform.up  trong game
        Vector2 dir = new Vector2(Mathf.Sin(-angleToRadian), Mathf.Cos(-angleToRadian));
        float angle = ((Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90f);

        ShootingFixedPosition(dir, angle);

        shootingTime = maxShootingTime;
    }
    public void ShootingRandomPosition(Vector2 dir, float angle)
    {
        //3 tia random goc
        angle += Random.Range(-distanceBettweenBulletRandom, distanceBettweenBulletRandom);
        dir.x = Mathf.Sin(-angle * Mathf.Deg2Rad);
        dir.y = Mathf.Cos(-angle * Mathf.Deg2Rad);

        Instantiate<BulletBase>(bullet, transform.position, Quaternion.identity).Init(speed, lifeTime, damage, dir, angle);
    }

    public void ShootingFixedPosition(Vector2 dir, float angle)
    {
        getInstanceShotgunBullet = GetBulletPooling();


        float anglePerBullet = maxAngleFixed / numberBullet;
        //doi so 60f sau

        if (getInstanceShotgunBullet == null)
        {
            BulletBase middleBullet = Instantiate<BulletBase>(bullet, transform.position, Quaternion.identity);
            //middleBullet.Init(speed, lifeTime, damage, dir, angle);
            bulletList.Add(middleBullet.gameObject);
            getInstanceShotgunBullet = middleBullet.gameObject;
        }

        getInstanceShotgunBullet.GetComponent<BulletBase>().Init(speed, lifeTime, damage, dir, angle);
        getInstanceShotgunBullet.transform.position = transform.position;
        getInstanceShotgunBullet.gameObject.SetActive(true);



        //toe vien dan theo goc hien tai cua player
        float leftAngle = angle;
        float rightAngle = angle;

        for (int i = numberBullet / 2; i > 0; i--)
        {
            leftAngle -= anglePerBullet;
            dir.x = Mathf.Sin(-leftAngle * Mathf.Deg2Rad);
            dir.y = Mathf.Cos(-leftAngle * Mathf.Deg2Rad);

            getInstanceShotgunBullet = GetBulletPooling();
            if (getInstanceShotgunBullet == null)
            {
                BulletBase leftBullet = Instantiate<BulletBase>(bullet, transform.position, Quaternion.identity);
                //leftBullet.Init(speed, lifeTime, damage, dir, leftAngle);
                bulletList.Add(leftBullet.gameObject);
                getInstanceShotgunBullet = leftBullet.gameObject;
            }

            getInstanceShotgunBullet.GetComponent<BulletBase>().Init(speed, lifeTime, damage, dir, leftAngle);
            getInstanceShotgunBullet.transform.position = transform.position;
            getInstanceShotgunBullet.gameObject.SetActive(true);


        }

        for (int i = numberBullet / 2; i < numberBullet - 1; i++)
        {
            rightAngle += anglePerBullet;
            dir.x = Mathf.Sin(-rightAngle * Mathf.Deg2Rad);
            dir.y = Mathf.Cos(-rightAngle * Mathf.Deg2Rad);

            getInstanceShotgunBullet = GetBulletPooling();
            if (getInstanceShotgunBullet == null)
            {
                BulletBase rightBullet = Instantiate<BulletBase>(bullet, transform.position, Quaternion.identity);
                //rightBullet.Init(speed, lifeTime, damage, dir, rightAngle);
                bulletList.Add(rightBullet.gameObject);
                getInstanceShotgunBullet = rightBullet.gameObject;
            }

            getInstanceShotgunBullet.GetComponent<BulletBase>().Init(speed, lifeTime, damage, dir, rightAngle);
            getInstanceShotgunBullet.transform.position = transform.position;
            getInstanceShotgunBullet.gameObject.SetActive(true);


        }
    }


}
