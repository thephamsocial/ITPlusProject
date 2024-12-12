using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    private static ObjectPooling instance;
    public static ObjectPooling Instance => instance;
    [SerializeField] private List<GameObject> bulletPoolList = new List<GameObject>();
    private void Awake()
    {
        instance = this;
    }
    public GameObject GetBulletPooling()
    {
        foreach (GameObject bullet in bulletPoolList)
        {
            if (bullet.activeSelf)
            {
                continue;
            }
            return bullet;
        }
        return null;
    }
    public void AddBullet(GameObject bullet)
    {
        bulletPoolList.Add(bullet);
    }
}
