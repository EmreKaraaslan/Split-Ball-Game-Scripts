using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameObject mainBall;
    [SerializeField] GameObject rightSideBall;
    [SerializeField] GameObject leftSideBall;
    [SerializeField] bool isDivided;
    [SerializeField] float distanceBetweenBalls;


    MeshRenderer mrMainBall;
    MeshRenderer mrRightSideBall;
    MeshRenderer mrLeftSideBall;

    float originalZPos;

    

   
    void Start()
    {
   
        mrMainBall = mainBall.GetComponent<MeshRenderer>();
        mrRightSideBall = rightSideBall.GetComponent<MeshRenderer>();
        mrLeftSideBall = leftSideBall.GetComponent<MeshRenderer>();

        originalZPos = mainBall.transform.position.z;
  
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDistance();
        CombineandDivideSituation();
        MeshRendererSituations();
       
      
    }

    void CalculateDistance()
    {
        distanceBetweenBalls = Mathf.Abs(rightSideBall.transform.position.z - leftSideBall.transform.position.z);
    }

    void CombineandDivideSituation()
    {
        if(distanceBetweenBalls<0.2f)
        {
            isDivided = false;
        }
        else 
        {
            isDivided = true;
        }
    }
    
    void MeshRendererSituations()
    {
        if(!isDivided)
        {
            mrMainBall.enabled = true;
            mrRightSideBall.enabled = false;
            mrLeftSideBall.enabled = false;
        }
        else if(isDivided)
        {
            mrMainBall.enabled = false;
            mrRightSideBall.enabled = true;
            mrLeftSideBall.enabled = true;
        }
    }
   
}
