using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
public class LineFlyingScript : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float amplitude;
    private float _zDirection1;
    private float _zDirection2;
    private float _currentZDirection;
    private float _startTime;
    public Vector3 tempPosition;
    
    private readonly Random _randomDir = new System.Random();
    private void Start()
    {
        tempPosition = transform.position;
        _zDirection1 = (float) (0.01 + _randomDir.NextDouble() * 0.05);
        _zDirection2 = _zDirection1 - _zDirection1 * 2;
        _currentZDirection = _zDirection1;
        _startTime = Time.time;
    }

    private void FixedUpdate()
    {
        if (Time.time - _startTime >= 1.5 & Time.time - _startTime <= 3)
        {
            _currentZDirection = _zDirection2;
        }

        if (Time.time - _startTime >= 3)
        {
            _currentZDirection = _zDirection1;
        }
        tempPosition = transform.position;
        tempPosition.x += horizontalSpeed;
        tempPosition.y += Mathf.Sin((Time.time - _startTime) * verticalSpeed) * amplitude;
        tempPosition.y += 0.03f;
        tempPosition.z += _currentZDirection;
        transform.position = tempPosition;
        Destroy(gameObject, 6);
    }
}
