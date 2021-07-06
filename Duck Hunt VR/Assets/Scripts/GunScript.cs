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
    public AudioClip fire;
    public AudioClip noammmo;
    public AudioClip reload;
    public Transform raycastOrigin;
    public LayerMask targetLayer;
    public int maxammo = 8;
    private int currentammo;

    void Reload()
    {
        currentammo = maxammo;
        audioSource.PlayOneShot(reload);
    }

    private void Update()
    {
        if (currentammo < 0)
            audioSource.PlayOneShot(noammmo);

        if (Vector3.Angle(transform.up, Vector3.up) > 100 && currentammo < maxammo)
            Reload();
    }

    public void Fire()
    {
        GameObject spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
        currentammo--;
        //audioSource.PlayOneShot(audioClip);
        Destroy(spawnedBullet, 2);
        FireRaycast();
    }

    private void FireRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hit,
            Mathf.Infinity, targetLayer))
        {
            if (hit.transform.GetComponent<ITargetInterface>() != null)
            {
                hit.transform.GetComponent<ITargetInterface>().TargetShot();
            }
        }
    }
}
