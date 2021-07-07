using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

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
    public TMPro.TextMeshPro ammoNumber;
    public string typeOfMag;

    void Reload()
    {
        if (_currentammo == maxammo)
        {
            if (typeOfMag == GameObject.FindGameObjectWithTag("Unused").ToString())
            {
                audioSource.PlayOneShot(reload);
                GameObject.FindGameObjectWithTag("Unused").tag = "Used";
            }
        }
            
    }

    private void Update()
    {
        //if (_currentammo == 0)
          //  audioSource.PlayOneShot(noammmo);

        //if (Vector3.Angle(transform.up, Vector3.up) > 100 && _currentammo < maxammo)
        if (_currentammo < maxammo)
        {   
            if (typeOfMag == GameObject.FindGameObjectWithTag("Unused").ToString())
                Reload();
        }

        ammoNumber.text = _currentammo.ToString();
    }

    public void Fire()
    {
        if (typeOfMag == GameObject.FindGameObjectWithTag("Unused").ToString())
            _currentammo = 0;
        
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
