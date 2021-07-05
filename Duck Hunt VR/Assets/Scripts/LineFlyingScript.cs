using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
public class LineFlyingScript : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public float amplitude;
    private float zDirection1;
    private float zDirection2;
    private float currentZDirection;
    private float startTime;
    public Vector3 tempPosition;
    
    private Random random_dir = new System.Random();
    private void Start()
    {
        tempPosition = transform.position;
        zDirection1 = (float) (0.01 + random_dir.NextDouble() * 0.05);
        zDirection2 = zDirection1 - zDirection1 * 2;
        currentZDirection = zDirection1;
        startTime = Time.time;
    }

    private void FixedUpdate()
    {
        if (Time.time - startTime >= 1.5 & Time.time - startTime <= 3)
        {
            currentZDirection = zDirection2;
        }

        if (Time.time - startTime >= 3)
        {
            currentZDirection = zDirection1;
        }
        tempPosition = transform.position;
        tempPosition.x += horizontalSpeed;
        tempPosition.y += Mathf.Sin((Time.time - startTime) * verticalSpeed) * amplitude;
        tempPosition.y += 0.03f;
        tempPosition.z += currentZDirection;
        transform.position = tempPosition;
        Destroy(gameObject, 6);
    }
}
