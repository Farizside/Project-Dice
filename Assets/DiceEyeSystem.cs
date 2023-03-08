using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceEyeSystem : MonoBehaviour
{
    private GameManager _gm => FindObjectOfType<GameManager>();
    private bool _isPressed = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == gameObject.tag && _isPressed == false)
        {
            _gm.score++;
            Debug.Log(_gm.score);
            _isPressed = true;
        }
    }
}
