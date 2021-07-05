using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour, ITargetInterface
{
    public Rigidbody rb;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public void TargetShot()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        if (GetComponent<LineFlyingScript>())
        {
            GetComponent<LineFlyingScript>().enabled = false;
        }
        else
        {
            GetComponent<SinusFlyingDuck>().enabled = false;
        }
        //GetComponent<LineFlyingScript>().enabled = false;
        audioSource.PlayOneShot(audioClip);
    }

    public void PlayAnimation()
    {
        
    }
}
