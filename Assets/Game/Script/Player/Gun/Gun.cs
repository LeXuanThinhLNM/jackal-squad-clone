using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // viet ham ban dan 1 giay ban 3 vien
    public GameObject bullet;
    public GameObject muzzleFlash;
    public Transform spawnBullet1;
    public Transform spawnBullet2;
    public Transform spawnBullet3;
    public Animator gunAnimator;
    public float timeShoot = 0.27f;
    public float force = 1000f;
    private float timeShootTemp = 0;
    private VehicleCharacter vehicleCharacter;
    private int currentSateAnimGun=0;
    public VehicleCharacter VehicleCharacter { set => vehicleCharacter = value; }
    private void Update()
    {
        (bool isShoot, Transform target)= vehicleCharacter.CheckAttack();
        if (isShoot)
            {
            Vector3 direction = target.position - this.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
            timeShootTemp += Time.deltaTime;
            if (timeShootTemp >= timeShoot)
            {
                Shoot(target);
                timeShootTemp = 0;
            }
        }
        else
        {
            if (currentSateAnimGun == 1)
            {
                gunAnimator.SetTrigger("ToIdle");
                currentSateAnimGun = 0;
            }
            if (muzzleFlash.active == true) muzzleFlash.SetActive(false);
            this.transform.localEulerAngles = new Vector3(0, 0, 0);
            timeShootTemp = 0;
        }
    }
    public void Shoot(Transform target)
    {
        muzzleFlash.SetActive(true);
        currentSateAnimGun = 1;
        gunAnimator.SetTrigger("ToAttack");
        GameObject bulletClone1 = Instantiate(bullet, spawnBullet1.position, spawnBullet1.rotation);
        GameObject bulletClone2 = Instantiate(bullet, spawnBullet2.position, spawnBullet2.rotation);
        GameObject bulletClone3 = Instantiate(bullet, spawnBullet3.position, spawnBullet3.rotation);
    }
}
