using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TargetController : MonoBehaviour, ITargetInterface
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    private Rigidbody _rigidbody;
    private bool _killed;
    
    public bool TargetShot()
    {
        if (_killed) return false;
        
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = true;
        GetComponent<Animator>().enabled = false;
        GetComponent<RandomFlyer>().enabled = false;
        audioSource.PlayOneShot(audioClip);
        _killed = true;
        return true;

    }

    public void PlayAnimation()
    {
        
    }
}
