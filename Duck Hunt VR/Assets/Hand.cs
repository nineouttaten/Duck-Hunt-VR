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

    private string animatorTriggerParam = "Trigger";

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
        Debug.Log(v);
    }

    void AnimateHand()
    {
        //Debug.Log("zashel");
        if (triggerCurrent != triggerTarget)
        {
            Debug.Log("nazhal");
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorTriggerParam, triggerCurrent);
        }
    }
}
