using Unity.VisualScripting;
using UnityEngine;

public class BulletXuyenThau: BulletBase
{
    private int countTarget = 0;
    protected override void BulletStatus(GameObject target)
    {
        IGetHit isCanGetHit = target.GetComponent<IGetHit>();

        if (isCanGetHit == null)
        {
            // Destroy(gameObject);
            return;
        }

        countTarget++;
        isCanGetHit.GetHit(damage);
        damage /= 2;
        speed /= 2;
        if (countTarget >= 3) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletStatus(collision.gameObject);
    }
}
