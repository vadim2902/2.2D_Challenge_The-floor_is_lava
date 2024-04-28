using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player; 
    public float CameraSpeed = 2.0f;

    void LateUpdate()
    {
        Vector3 currentPosition = transform.position;

        Vector3 targetPosition = new Vector3(Player.position.x, currentPosition.y, currentPosition.z);

        transform.position = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * CameraSpeed);
    }

}
