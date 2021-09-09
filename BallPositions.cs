using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPositions : MonoBehaviour
{
    [SerializeField] GameObject mainBall;
    [SerializeField] GameObject rightSideBall;
    [SerializeField] GameObject leftSideBall;
    [SerializeField] bool isDivided;
    [SerializeField] float distanceBetweenBalls;
    [SerializeField] GameObject planePath3;


    MeshRenderer mrMainBall;
    MeshRenderer mrRightSideBall;
    MeshRenderer mrLeftSideBall;

    SphereCollider scMainBall;
    SphereCollider scRightSideBall;
    SphereCollider scLeftSideBall;

    float forwardSpeed = 4f;
    float leftrightSpeed = 3f;
    float originalZPos;




    void Start()
    {

        mrMainBall = mainBall.GetComponent<MeshRenderer>();
        mrRightSideBall = rightSideBall.GetComponent<MeshRenderer>();
        mrLeftSideBall = leftSideBall.GetComponent<MeshRenderer>();

        scMainBall=mainBall.GetComponent<SphereCollider>();
        scRightSideBall=rightSideBall.GetComponent<SphereCollider>();
        scLeftSideBall=leftSideBall.GetComponent<SphereCollider>();

        //scMainBall.enabled = true;
        //scRightSideBall.enabled = false;
        //scLeftSideBall.enabled = false;

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
        if (distanceBetweenBalls < 0.2f)
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
        if (!isDivided)
        {
            mrMainBall.enabled = true;
            mrRightSideBall.enabled = false;
            mrLeftSideBall.enabled = false;

            mainBall.layer = LayerMask.NameToLayer("Balls");
            rightSideBall.layer = LayerMask.NameToLayer("NoCollidewithCoinandObstale");
            leftSideBall.layer = LayerMask.NameToLayer("NoCollidewithCoinandObstale");

            planePath3.SetActive(false);
            //scMainBall.enabled = true;
            //scRightSideBall.enabled = false;
            //scLeftSideBall.enabled = false;
        }
        else if (isDivided)
        {
            mrMainBall.enabled = false;
            mrRightSideBall.enabled = true;
            mrLeftSideBall.enabled = true;

            mainBall.layer = LayerMask.NameToLayer("NoCollidewithCoinandObstale");
            rightSideBall.layer = LayerMask.NameToLayer("Balls");
            leftSideBall.layer = LayerMask.NameToLayer("Balls");

            planePath3.SetActive(true);
            //mainBall.GetComponent<SphereCollider>().enabled = false;
            //rightSideBall.GetComponent<SphereCollider>().enabled = true;
            //leftSideBall.GetComponent<SphereCollider>().enabled = true;
        }
    }
}
