using Unity.VisualScripting;
using UnityEngine;

public class BulletXuyenThau: BulletBase
{
    private int countTarget = 0;
    protected override void BulletDetect(GameObject target)
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
        if (countTarget >= 3) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletDetect(collision.gameObject);
    }
}
