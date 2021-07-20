using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    Animator animator;
    public float speed;
    private float triggerTarget;

    private float triggerCurrent;

    private float gripTarget;

    private float gripCurrent;
    
    private string animatorTriggerParam = "Trigger";
    private string animatorGripParam = "Grip";

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
    }
    

    public void SetTrigger(float v)
    {
        triggerTarget = v;
    }

    public void SetGrip(float v)
    {
        gripTarget = v;
    }
    void AnimateHand()
    {
        //Debug.Log("zashel");
        if (triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorTriggerParam, triggerCurrent);
        }
        if (gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorGripParam, gripCurrent);
        }
    }
}
