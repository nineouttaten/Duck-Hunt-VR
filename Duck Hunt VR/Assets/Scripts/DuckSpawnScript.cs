using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class DuckSpawnScript : MonoBehaviour
{
    public float speed = 1;
    public GameObject lineDuck;
    public GameObject sinusDuck;
    public Transform spawn;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Transform raycastOrigin;
    public LayerMask targetLayer;
    public GameObject gun;
    private GameObject duck;
    private Vector3 randomSpawnPosition;
    private Random randomPos = new System.Random();
    private int typeOfDuck;
    public void Spawn()
    {
        randomSpawnPosition = spawn.position;
        randomSpawnPosition.z += randomPos.Next(-2, 2);
        typeOfDuck = randomPos.Next(0, 3);
        if (typeOfDuck == 0)
        {
            duck = lineDuck;
        }
        else
        {
            duck = sinusDuck;
        }
        GameObject spawnedDuck = Instantiate(duck, randomSpawnPosition, spawn.rotation);
        //spawnedDuck.GetComponent<Rigidbody>().velocity = speed * spawn.forward;
        //Repeat();
    }

    public void SpawnWave()
    {
        Invoke("Spawn", 1);
        Invoke("Spawn", 2);
        Invoke("Spawn", 3);
    }
    public IEnumerator Wait8Seconds()
    {
        yield return new WaitForSeconds(8f);
    }

    public void StartGame()
    {
        StartCoroutine(Game());
    }
    public IEnumerator Game()
    {
        bool killedWave = false;
        audioSource.PlayOneShot(audioClip);
        yield return new WaitForSeconds(2.0f);
        SpawnWave();
        for (int i = 0; i < 15; i++)
        {
            yield return new WaitForSeconds(1.0f);
            if (CheckForKills())
            {
                killedWave = true;
                break;
            }
        }
        Debug.Log("vse");
    }

    public bool CheckForKills()
    {
        if (gun.GetComponent<GunScript>().numberOfKills == 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Start()
    {
        //StartCoroutine(Spawn());
    }

    void Repeat()
    {
        //StartCoroutine(Spawn());
    }
    
}
