using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlatformXMovement : MonoBehaviour
{
    public float Amplitude = 5.0f;  
    public float Frequency = 2.0f;
    private float _objectPositionX;

    private void Start()
    {
        _objectPositionX = transform.position.x;
    }

    void Update()
    {
        float xPosition = Amplitude * Mathf.Sin(Frequency * Time.time);
        transform.position = new Vector3(xPosition + _objectPositionX, transform.position.y, transform.position.z);
    }
}
