using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunScript : MonoBehaviour
{
    [SerializeField] private float speed = 40;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform barrel;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private int maxAmmo = 8;
    
    private bool _shot;
    private MagazineAmmo _magazine;

    public int numberOfKills = 0;
    private bool IsLoaded => _magazine != null && _magazine.AmmoCount > 0;

    public void Fire()
    {
        if (!IsLoaded) return;

        var spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
        audioSource.PlayOneShot(audioClip);
        Destroy(spawnedBullet, 2);
        
        FireRaycast();

        _magazine.AmmoCount--;
    }

    public void SetMagazine(SelectEnterEventArgs args)
    {
        if (args.interactable.TryGetComponent<MagazineAmmo>(out var magazineAmmo))
        {
            _magazine = magazineAmmo;
        }
    }

    public void ClearMagazine(SelectExitEventArgs args)
    {
        _magazine = null;
    }

    private void FireRaycast()
    {
        if (!Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out var hit,
            Mathf.Infinity, targetLayer)) return;
        
        if (hit.transform.GetComponent<ITargetInterface>() == null) return;
        
        _shot = hit.transform.GetComponent<ITargetInterface>().TargetShot();
        
        if (_shot) { numberOfKills += 1; }
    }
}