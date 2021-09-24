using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
public class SinusFlyingDuck : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float amplitude;
    [SerializeField] private Vector3 tempPosition;
    private float _zDirection;
    private float _startTime;
    
    
    private readonly Random _randomDir = new System.Random();
    private void Start()
    {
        tempPosition = transform.position;
        _zDirection = (float) (-0.03 + _randomDir.NextDouble() * 0.06);
        _startTime = Time.time;
    }

    private void FixedUpdate()
    {
        tempPosition = transform.position;
        tempPosition.x += horizontalSpeed;
        tempPosition.y += Mathf.Sin((Time.time - _startTime) * verticalSpeed) * amplitude;
        tempPosition.y += 0.03f;
        tempPosition.z += _zDirection;
        transform.position = tempPosition;
        Destroy(gameObject, 6);
    }
}
