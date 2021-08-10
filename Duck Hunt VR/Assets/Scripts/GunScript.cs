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
    private bool _shot;
    public void Fire()
    {
        GameObject spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
        audioSource.PlayOneShot(audioClip);
        Destroy(spawnedBullet, 2);
        FireRaycast();
    }

    private void FireRaycast()
    {
        RaycastHit hit;

        if (!Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hit,
            Mathf.Infinity, targetLayer)) return;
        if (hit.transform.GetComponent<ITargetInterface>() == null) return;
        _shot = hit.transform.GetComponent<ITargetInterface>().TargetShot();
        if (_shot) numberOfKills += 1;
        
    }
}
