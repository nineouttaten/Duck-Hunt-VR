using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawnScript : MonoBehaviour
{
    public float speed = 1;
    public GameObject duck;
    public Transform spawn;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Transform raycastOrigin;
    public LayerMask targetLayer;
    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject spawnedDuck = Instantiate(duck, spawn.position, spawn.rotation);
        //spawnedDuck.GetComponent<Rigidbody>().velocity = speed * spawn.forward;
        //audioSource.PlayOneShot(audioClip);
        Repeat();
    }

    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Repeat()
    {
        StartCoroutine(Spawn());
    }
    
}
