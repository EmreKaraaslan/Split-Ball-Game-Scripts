using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{

    GameOver gameOver;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
      
        gameOver = FindObjectOfType<GameOver>();
    }

    // Update is called once per frame
  
    void OnCollisionEnter(Collision collision)
    {
        gameOver.FinishGameCrash();
    }
}
