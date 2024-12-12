using Unity.VisualScripting;
using UnityEngine;

public class BulletThuong : BulletBase
{
    protected override void BulletDetect(GameObject target)
    {
        IGetHit isCanGetHit = target.GetComponent<IGetHit>();
        if (isCanGetHit != null)
        {
            gameObject.SetActive(false);
            isCanGetHit.GetHit(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletDetect(collision.gameObject);
    }

}
