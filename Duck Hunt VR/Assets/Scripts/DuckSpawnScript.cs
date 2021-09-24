using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = System.Random;

public class DuckSpawnScript : MonoBehaviour
{
    
    [SerializeField] private Text gameText;
    [SerializeField] private GameObject duck;
    [SerializeField] private Transform[] spawn;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip startGameClip;
    [SerializeField] private AudioClip wonWave;
    [SerializeField] private AudioClip loseWave;
    [SerializeField] private GameObject gun;
    
    private int _score;
    private Vector3 _randomSpawnPosition;
    private readonly Random _randomPos = new Random();
    public void Spawn()
    {
        _randomSpawnPosition = spawn[_randomPos.Next(0, 2)].position;

        Instantiate(duck, _randomSpawnPosition, spawn[0].rotation);
        //spawnedDuck.GetComponent<Rigidbody>().velocity = speed * spawn.forward;
        //Repeat();
    }

    private void SpawnWave()
    {
        Invoke(nameof(Spawn), 1);
        Invoke(nameof(Spawn), 2);
        Invoke(nameof(Spawn), 3);
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
    
    private IEnumerator Game()
    {
        var killedWave = false;
        yield return new WaitForSeconds(8.0f);
        for (var i = 0; i < 5; i++)
        {
            SpawnWave();
            for (var j = 0; j < 120; j++)
            {
                yield return new WaitForSeconds(1.0f);
                if (!CheckForKills()) continue;
                killedWave = true; 
                break;
            }

            audioSource.PlayOneShot(killedWave ? wonWave : loseWave);
            _score += 100 * gun.GetComponent<GunScript>().numberOfKills;
            gameText.text = _score.ToString();
            gun.GetComponent<GunScript>().numberOfKills = 0;
            killedWave = false;
        }
        
        Debug.Log("vse");
    }
    
    private bool CheckForKills()
    {
        return gun.GetComponent<GunScript>().numberOfKills == 3;
    }
    
}
