using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TargetController : MonoBehaviour, ITargetInterface
{
    private Rigidbody rb;
    private bool killed = false;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public bool TargetShot()
    {
        if (killed == false)
        {
            rb = GetComponent<Rigidbody>();
                    rb.useGravity = true;
                    GetComponent<PlayableDirector>().enabled = false;
                    if (GetComponent<LineFlyingScript>())
                    {
                        GetComponent<LineFlyingScript>().enabled = false;
                    }
                    else
                    {
                        GetComponent<SinusFlyingDuck>().enabled = false;
                    }
                    audioSource.PlayOneShot(audioClip);
                    killed = true;
                    return true;
        }

        return false;

    }

    public void PlayAnimation()
    {
        
    }
}
