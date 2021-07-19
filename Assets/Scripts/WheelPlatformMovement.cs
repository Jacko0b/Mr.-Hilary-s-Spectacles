using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelPlatformMovement : MonoBehaviour
{
    public float wheelSpeed = -0.2f;
    void Awake()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.GetComponent<Transform>().Rotate(0, 0, wheelSpeed, Space.Self);
    }
}
