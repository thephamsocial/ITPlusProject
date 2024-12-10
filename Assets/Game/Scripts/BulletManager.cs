using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private List<BulletBase> bulletList = new List<BulletBase>();
    [SerializeField] private GunController gunController;
    [SerializeField] private int i = 0;
    
    // Update is called once per frame
    void Update()
    {
        gunController.ChangeBullet(bulletList[i]);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            i++;
        }
        if (i >= bulletList.Count) i = 0;
    }
}
