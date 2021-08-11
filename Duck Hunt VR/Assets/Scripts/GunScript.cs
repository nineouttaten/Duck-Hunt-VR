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
    public AudioClip audioClip;
    public Transform raycastOrigin;
    public LayerMask targetLayer;
    public int maxAmmo = 8;
    public int numberOfKills = 0;
    private bool shot;

    private MagazineAmmo magazine;

    private bool IsLoaded => magazine != null && magazine.AmmoCount > 0;

    public void Fire()
    {
        if (!IsLoaded) return;

        var spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
        audioSource.PlayOneShot(audioClip);
        Destroy(spawnedBullet, 2);
        FireRaycast();

        magazine.AmmoCount--;
    }

    public void SetMagazine(SelectEnterEventArgs args)
    {
        if (args.interactable.TryGetComponent<MagazineAmmo>(out var magazineAmmo))
        {
            magazine = magazineAmmo;
        }
    }

    public void ClearMagazine(SelectExitEventArgs args)
    {
        magazine = null;
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