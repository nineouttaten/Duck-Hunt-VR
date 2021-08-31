using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class DuckSpawnScript : MonoBehaviour
{
    
    public float speed = 1;
    public GameObject startGameButton;
    public Text gameText;
    public GameObject Duck;
    public Transform spawn;
    public AudioSource audioSource;
    public AudioClip startGameClip;
    public AudioClip wonWave;
    public AudioClip loseWave;
    public Transform raycastOrigin;
    public LayerMask targetLayer;
    public GameObject gun;
    private int score = 0;
    private Vector3 randomSpawnPosition;
    private Random randomPos = new System.Random();
    private int typeOfDuck;
    public void Spawn()
    {
        randomSpawnPosition = spawn.position;
        randomSpawnPosition.z += randomPos.Next(-2, 2);

        GameObject spawnedDuck = Instantiate(Duck, randomSpawnPosition, spawn.rotation);
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
        audioSource.PlayOneShot(startGameClip);
        
    }
    public IEnumerator Game()
    {
        bool killedWave = false;
        yield return new WaitForSeconds(8.0f);
        for (int i = 0; i < 5; i++)
        {
            SpawnWave();
            for (int j = 0; j < 120; j++)
            {
                yield return new WaitForSeconds(1.0f);
                if (CheckForKills())
                {
                    killedWave = true; 
                    break;
                }
            }

            if (killedWave)
            {
                //Debug.Log("ubil");
                audioSource.PlayOneShot(wonWave);
            }
            else
            {
                //Debug.Log("ne ubil");
                audioSource.PlayOneShot(loseWave);
            }
            score += 100 * gun.GetComponent<GunScript>().numberOfKills;
            gameText.text = score.ToString();
            gun.GetComponent<GunScript>().numberOfKills = 0;
            killedWave = false;
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
    
}
