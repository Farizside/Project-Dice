using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceEyeSystem : MonoBehaviour
{
    private static GameManager Gm => FindObjectOfType<GameManager>();
    private bool _isPressed = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == gameObject.tag && _isPressed == false)
        {
            Gm.score++;
            Debug.Log(Gm.score);
            _isPressed = true;
        }
    }
}
