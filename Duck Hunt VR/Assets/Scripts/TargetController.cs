using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour, ITargetInterface
{
    public Rigidbody rb;
    public void TargetShot()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        GetComponent<LineFlyingScript>().enabled = false;
    }

    public void PlayAnimation()
    {
        
    }
}
