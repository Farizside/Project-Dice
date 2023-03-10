using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;

    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)] public float smoothFactor = 0.5f;

    public bool lookAtPlayer = false;
    void Start()
    {
        _cameraOffset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        Vector3 newPos = playerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if (lookAtPlayer)
        {
            transform.LookAt(playerTransform);
        }
    }
}
