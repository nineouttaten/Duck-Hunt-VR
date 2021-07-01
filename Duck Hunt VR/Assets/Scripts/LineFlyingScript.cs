using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class LineFlyingScript : MonoBehaviour
{
    public float speed;
    public Vector3 dir;
    private Random random_dir = new System.Random();
    private void Start()
    {
        speed += (float) (random_dir.NextDouble() * 0.9);
        dir.y += (float) (random_dir.NextDouble() * 0.5);
        dir.z += (float) (random_dir.NextDouble() * 1);
    }

    private void FixedUpdate()
    {
        transform.Translate(speed * dir * Time.deltaTime, Space.World);
    }
}
