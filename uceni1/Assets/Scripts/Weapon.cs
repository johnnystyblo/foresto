using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePointBullet;
    public Transform firePointBaseball;
    public GameObject bulletPrefab;
    public GameObject baseballPrefab;
    private float canShoot = 0f;
    private float canThrow = 0f;
    private string BULLET_FRIENDLY = "Friendly";
    // Update is called once per frame
    void Update()
    {
        ShootIf();
    }
    void ShootBullet()
    {
        Instantiate(bulletPrefab, firePointBullet.position, firePointBullet.rotation);
        bulletPrefab.tag = BULLET_FRIENDLY;
    }
    public void ThrowBaseball()
    {
        Instantiate(baseballPrefab, firePointBaseball.position, firePointBaseball.rotation);
        baseballPrefab.tag = BULLET_FRIENDLY;
    }
    public void ShootIf()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > canShoot)
        {
            ShootBullet();
            canShoot = Time.time + 1f;
        }
        if (Input.GetButtonDown("Fire2") && Time.time > canThrow)
        {
            ThrowBaseball();
            canThrow = Time.time + 10f;
        }
        
    }
}