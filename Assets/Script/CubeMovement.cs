using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public int speed = 300;
    private static GameManager Gm => FindObjectOfType<GameManager>();
    public bool _isMoving = false;

    public bool[] border;

    void Update()
    {
        if (_isMoving || !Gm.isPlaying)
        {
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow) && border[0])
        {
            StartCoroutine(Roll(Vector3.right));
            border[2] = true;
        } else if (Input.GetKey(KeyCode.LeftArrow) && border[2])
        {
            StartCoroutine(Roll(Vector3.left));
            border[0] = true;
        } else if (Input.GetKey(KeyCode.UpArrow) && border [3])
        {
            StartCoroutine(Roll(Vector3.forward));
            border[1] = true;
        } else if (Input.GetKey(KeyCode.DownArrow) && border[1])
        {
            StartCoroutine(Roll(Vector3.back));
            border[3] = true;
        }
    }

    IEnumerator Roll(Vector3 direction)
    {
        _isMoving = true;

        float remainingAngle = 90;
        Vector3 rotationCenter = transform.position + direction / 2 + Vector3.down / 2 ;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

        while (remainingAngle > 0)
        {
            float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;
            yield return null;
        }
        
        _isMoving = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Bottom")
        {
            border[1] = false;
        }
        if (collision.tag == "Left")
        {
            border[2] = false;
        }
        if (collision.tag == "Right")
        {
            border[0] = false;
        }
        if (collision.tag == "Top")
        {
            border[3] = false;
        }
    }
}
