using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class DuckSpawnScript : MonoBehaviour
{
    public float speed = 1;
    public GameObject duck;
    public Transform spawn;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Transform raycastOrigin;
    public LayerMask targetLayer;
    private Vector3 randomSpawnPosition;
    private Random randomPos = new System.Random();
    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.8f);
        randomSpawnPosition = spawn.position;
        randomSpawnPosition.z += randomPos.Next(-2, 2);
        GameObject spawnedDuck = Instantiate(duck, randomSpawnPosition, spawn.rotation);
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
