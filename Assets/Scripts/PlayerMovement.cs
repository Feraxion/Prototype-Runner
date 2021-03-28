﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float controlSpeed;

    //Touch settings
    [SerializeField] bool isTouching;
    float touchPosX;
    Vector3 direction;


    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.forward * movementSpeed * Time.fixedDeltaTime;
        if (isTouching)
        {
            touchPosX += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
        }

        transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z);
    }

    void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }
}
