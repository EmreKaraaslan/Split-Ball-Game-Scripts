using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollecCoin : MonoBehaviour
{

    GameOver gameOver;
    BallMovement ballMovement;
    float fallDownHight = 30f;
  

    
    void Start()
    {
        
        gameOver = FindObjectOfType<GameOver>();
        ballMovement = FindObjectOfType<BallMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        FallDownSituation();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Coin")
        {
            other.gameObject.tag = "AlreadyCollided";
            gameOver.IncreaseColledtedCoin();
            Destroy(other.gameObject, 0.1f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="PathBase")
        {
           collision.gameObject.tag= "AlreadyCollided";
           gameOver.SpeedUIAction();
           ballMovement.forwardSpeed *= 1.1f; 
           
        }
    }
    void FallDownSituation()
    {
        if(transform.position.y<fallDownHight)
        {
            gameOver.FinishGameFallDown();
        }
    }

    
}
