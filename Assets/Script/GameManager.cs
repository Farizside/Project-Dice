using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public int N => GameObject.FindObjectsOfType(typeof(DiceEyeSystem)).Length;
    private static CubeMovement Cm => GameObject.FindObjectOfType<CubeMovement>();

    public bool isPlaying;
    
    void Start()
    {
        isPlaying = true;
        Debug.Log(N);
        score = 0;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        isPlaying = false;
    }
}
