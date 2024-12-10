using Unity.VisualScripting;
using UnityEngine;

public class BulletThuong : BulletBase
{
    protected override void BulletStatus(GameObject target)
    {
        IGetHit isCanGetHit = target.GetComponent<IGetHit>();
        if (isCanGetHit != null)
        {
            Destroy(gameObject);
            isCanGetHit.GetHit(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletStatus(collision.gameObject);
    }

}
