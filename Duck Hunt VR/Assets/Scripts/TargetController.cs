using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TargetController : MonoBehaviour, ITargetInterface
{
    private Rigidbody _rigidbody;
    private bool _killed;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public bool TargetShot()
    {
        if (!_killed)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.useGravity = true;
            GetComponent<PlayableDirector>().enabled = false;
            GetComponent<RandomFlyer>().enabled = false;
        }

        return false;

    }

    public void PlayAnimation()
    {
        
    }
}
