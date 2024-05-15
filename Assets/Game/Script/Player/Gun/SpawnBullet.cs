using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    // viet ham ban dan 1 giay ban 3 vien
    public GameObject bullet;
    public GameObject muzzleFlash;
    public Transform spawnBullet1;
    public Transform spawnBullet2;
    public Transform spawnBullet3;
    public float timeShoot = 0.33f;
    public float force = 1000f;
    private bool isShoot = true;
    private float timeShootTemp = 0;
    private void Update()
    {
        if (isShoot)
        {
            timeShootTemp += Time.deltaTime;
            if (timeShootTemp >= timeShoot)
            {
                timeShootTemp = 0;
                muzzleFlash.SetActive(true);
                GameObject bulletClone1 = Instantiate(bullet, spawnBullet1.position, spawnBullet1.rotation);
                GameObject bulletClone2 = Instantiate(bullet, spawnBullet2.position, spawnBullet2.rotation);
                GameObject bulletClone3 = Instantiate(bullet, spawnBullet3.position, spawnBullet3.rotation);

            }
        }
    }
}
