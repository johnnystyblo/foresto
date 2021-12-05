using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private float canShoot = 0f;
    private string BULLET_FRIENDLY = "Friendly";
    // Update is called once per frame
    void Update()
    {
        ShootIf();
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletPrefab.tag = BULLET_FRIENDLY;
    }
    public void ShootIf()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > canShoot)
        {
            Shoot();
            canShoot = Time.time + 1f;
        }

    }
}