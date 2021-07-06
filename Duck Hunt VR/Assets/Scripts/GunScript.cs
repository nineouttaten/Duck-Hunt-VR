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
    private int _currentammo = 1;

    void Reload()
    {
        _currentammo = maxammo;
        audioSource.PlayOneShot(reload);
    }

    private void Update()
    {
        //if (_currentammo == 0)
          //  audioSource.PlayOneShot(noammmo);

        if (Vector3.Angle(transform.up, Vector3.up) > 100 && _currentammo < maxammo)
            Reload();
    }

    public void Fire()
    {
        if (_currentammo == 0)
        {
            audioSource.PlayOneShot(noammmo);
        }
            
        else
        {
            GameObject spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
                    
            spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
            _currentammo--;
            //audioSource.PlayOneShot(audioClip);
            Destroy(spawnedBullet, 2);
            FireRaycast();
        }
        
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
