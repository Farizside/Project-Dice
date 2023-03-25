using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceEyeSystem : MonoBehaviour
{
    private static GameManager Gm => FindObjectOfType<GameManager>();
    private bool _isPressed = false;
    private Renderer _mr;
    public Color color;

    private void Start()
    {
        _mr = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == gameObject.tag && _isPressed == false)
        {
            Gm.score++;
            Debug.Log(Gm.score);
            _isPressed = true;
            _mr.material.color = color;
            if (Gm.score == Gm.N)
            {
                Gm.GameOver();
            }
        }
    }
}
