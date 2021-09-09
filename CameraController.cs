using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject mainBall;
    BallMovement ballMovement;
    Vector3 offset;
   

    void Start()
    {
        offset = transform.position - mainBall.transform.position;

    }

    void LateUpdate()
    {
        transform.position = mainBall.transform.position + offset;
    }
  
}
