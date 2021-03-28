using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]private Rigidbody PlayerRigidbody;
    [SerializeField]private int moveSpeed;
    
    private float width;
    private float height;
    private Vector3 position;


    

    void Start()
    {
        Application.targetFrameRate = 60;

    }
 
    void Update()
    {
        PlayerRigidbody.AddForce(Vector3.forward * Time.deltaTime * moveSpeed);
        
        float speed =  PlayerRigidbody.velocity.magnitude;

        // if (speed < 5f) ; 
        // {
        //     PlayerRigidbody.AddForce((Vector3.forward * Time.deltaTime * moveSpeed) / 15);
        //
        // }

        if (Input.GetKey(KeyCode.A))
        {
            PlayerRigidbody.AddForce(Vector3.left * Time.deltaTime * (moveSpeed * 1.5f));
        }

        if (Input.GetKey(KeyCode.D))
        {
            PlayerRigidbody.AddForce(Vector3.right * Time.deltaTime *(moveSpeed * 1.5f));
        }

        // if (Input.touchCount > 0) // user is touching the screen with a single touch
        // {
        //     Touch touch = Input.GetTouch(0);
        //     
        //     Vector2 pos = touch.position;
        //
        //     TouchMovement(pos);
        // }
    }

    /*void TouchMovement(Vector2 pos)
    {
        int i = 0 ;

        while(i < Input.touchCount){

            if    (pos.x > Screen.width / 2)
            {
                PlayerRigidbody.AddForce((Vector3.right * Time.deltaTime * moveSpeed) * 1.5f );
            }

            if    (pos.x < Screen.width / 2)
            {
                PlayerRigidbody.AddForce((Vector3.left * Time.deltaTime * moveSpeed) * 1.5f );
            }
            ++i;
        }
    }*/

   
    
   

   
    
   
}
