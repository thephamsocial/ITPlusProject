using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private List<BulletBase> bulletList = new List<BulletBase>();
    [SerializeField] private GunControllerBase gun;
    [SerializeField] private int i = 0;

    // Update is called once per frame
    private void Awake()
    {
        if (gun == null) gun = FindFirstObjectByType<GunControllerBase>();
    }
    void Update()
    {
        gun.ChangeBullet(bulletList[i]);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gun.bulletList.Clear();
            i++;
        }
        if (i >= bulletList.Count) i = 0;
    }
}
