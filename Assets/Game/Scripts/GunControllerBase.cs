using System.Collections.Generic;
using UnityEngine;

public abstract class GunControllerBase : MonoBehaviour
{
    [Space(10)]
    [Header("-------------Gun Base Config--------------")]
    [SerializeField] protected BulletBase bullet;
    [SerializeField] protected float speed, lifeTime, damage, maxShootingTime;
    protected PlayerController playerController;
    protected float shootingTime;

    [SerializeField] public List<GameObject> bulletList = new List<GameObject>();

    public virtual void Init(PlayerController playerController)
    {
        this.playerController = playerController;
        shootingTime = maxShootingTime;
    }
    // Update is called once per frame

    public abstract void Fire();
  
    public virtual void ChangeBullet(BulletBase bullet)
    {
        this.bullet = bullet;
    }
    protected virtual GameObject GetBulletPooling()
    {
        foreach(GameObject bullet in bulletList)
        {
            if (bullet.activeSelf)
            {
                continue;
            }
            return bullet;
        }
        return null;
    }
    
}
