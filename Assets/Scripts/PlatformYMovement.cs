using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlatformYMovement : MonoBehaviour
{
    public float Amplitude = 5.0f;  
    public float Frequency = 2.0f;
    private float _objectPositionY;

    private void Start()
    {
        _objectPositionY = transform.position.y;
    }

    void Update()
    {
        float yPosition = Amplitude * Mathf.Sin(Frequency * Time.time);
        transform.position = new Vector3(transform.position.x, yPosition + _objectPositionY, transform.position.z);
    }
}
