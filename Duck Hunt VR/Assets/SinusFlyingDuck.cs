using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
public class SinusFlyingDuck : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public float amplitude;

    private float startTime;
    public Vector3 tempPosition;
    
    private Random random_dir = new System.Random();
    private void Start()
    {
        tempPosition = transform.position;
        startTime = Time.time;
    }

    private void FixedUpdate()
    {
        tempPosition = transform.position;
        tempPosition.x += horizontalSpeed;
        tempPosition.y += Mathf.Sin((Time.time - startTime) * verticalSpeed) * amplitude;
        transform.position = tempPosition;
    }
}
