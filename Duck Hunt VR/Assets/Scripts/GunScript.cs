using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float speed = 40;
    public GameObject bullet;
    public Transform barrel;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Transform raycastOrigin;
    public LayerMask targetLayer;
    public int numberOfKills = 0;
    private bool shot;
    public static int currentammo = 0;
    public int maxammo = 8;

    private void Start()
    {
        currentammo = 0;
    }

    void Reload()
    {
        currentammo = maxammo;
        magazineAmmo.isUsed = 1;
    }

    private void Update()
    {
        if (currentammo < maxammo && magazineAmmo.isUsed == 0)
        {   
            Reload();
        }
    }

    public void Fire()
    {
        GameObject spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
        //audioSource.PlayOneShot(audioClip);
        Destroy(spawnedBullet, 2);
        FireRaycast();
        currentammo--;
        if (currentammo == 0)
            magazineAmmo.isUsed = 1;
    }

    private void FireRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hit,
            Mathf.Infinity, targetLayer))
        {
            if (hit.transform.GetComponent<ITargetInterface>() != null)
            {
                shot = hit.transform.GetComponent<ITargetInterface>().TargetShot();
                if (shot)
                {
                    numberOfKills += 1;
                }
            }

        }
    }
}
