using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] GameObject mainBall;
    [SerializeField] GameObject rightSideBall;
    [SerializeField] GameObject leftSideBall;

    Rigidbody rbMainBall;
    Rigidbody rbRightSideBall;
    Rigidbody rbLeftSideBall;

    [SerializeField] bool jumped;

    public float forwardSpeed = 20f;
    float leftrightSpeed = 3f;
    float jumpForce = 10f;
    float originalZPos;
    float fallMultiplier=3f;
    float lowJumpMultiplier=2f;

    void Start()
    {
        rbMainBall = mainBall.GetComponent<Rigidbody>();
        rbRightSideBall = rightSideBall.GetComponent<Rigidbody>();
        rbLeftSideBall = leftSideBall.GetComponent<Rigidbody>();
        originalZPos = mainBall.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        ForwardMovement();
        LeftRighMovement();
        Jump();      
    }
   


    void ForwardMovement()
    {
        mainBall.transform.Translate(forwardSpeed * Time.deltaTime, 0, 0);
        leftSideBall.transform.Translate(forwardSpeed * Time.deltaTime, 0, 0);
        rightSideBall.transform.Translate(forwardSpeed * Time.deltaTime, 0, 0);
    }

    void LeftRighMovement()
    {
        float leftrightInput = Input.GetAxis("Horizontal") * leftrightSpeed;
        MoveBallsAway(leftrightInput);
        MoveBallsBack(leftrightInput);
    }

    void MoveBallsBack(float leftrightInput)
    {
        if (leftrightInput < 0 && rightSideBall.transform.position.z > originalZPos)
        {
            rightSideBall.transform.Translate(0, 0, leftrightInput * Time.deltaTime);
         
            if (Mathf.Abs(rightSideBall.transform.position.z - originalZPos) < 0.1f)
            {
                PlaceBalls();
            }
        }

        if (leftrightInput < 0 && leftSideBall.transform.position.z < originalZPos)
        {
        
            leftSideBall.transform.Translate(0, 0, -leftrightInput * Time.deltaTime);
            if (Mathf.Abs(leftSideBall.transform.position.z - originalZPos) < 0.1f)
            {
                PlaceBalls();
            }
        }
    }

    void MoveBallsAway(float leftrightInput)
    {
        if (leftrightInput > 0 && rightSideBall.transform.position.z >= originalZPos)
        {

            rightSideBall.transform.Translate(0, 0, leftrightInput * Time.deltaTime);
        }

        if (leftrightInput > 0 && leftSideBall.transform.position.z <= originalZPos)
        {

            leftSideBall.transform.Translate(0, 0, -leftrightInput * Time.deltaTime);
        }
    }

    void PlaceBalls()
    {
        rightSideBall.transform.position = new Vector3(rightSideBall.transform.position.x, rightSideBall.transform.position.y, originalZPos);
        leftSideBall.transform.position = new Vector3(leftSideBall.transform.position.x, leftSideBall.transform.position.y, originalZPos);
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && !jumped)
        {
            rbMainBall.velocity = Vector3.up * jumpForce*Time.deltaTime*50;
            rbRightSideBall.velocity = Vector3.up * jumpForce * Time.deltaTime*50;
            rbLeftSideBall.velocity = Vector3.up * jumpForce * Time.deltaTime*50;

            jumped = true;
            Invoke("JumpDelayer", 3);
        }
    }

    void JumpDelayer()
    {
        jumped = false;
    }

    }

