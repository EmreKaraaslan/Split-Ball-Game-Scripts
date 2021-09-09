using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotation : MonoBehaviour
{
    float rotationSpeed = 3f;
 

    // Update is called once per frame
    void Update()
    {
        RotatePickup();
    }
    void RotatePickup()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime * 50,0, 0);
    }
       
}
