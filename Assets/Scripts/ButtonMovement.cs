using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMovement : MonoBehaviour
{
    public float yMin ;
    public float yMax ;
    public float animSpeed;

    public bool moveDown;
    public bool moveUp;
    
    Vector3 movement;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = gameObject.transform.position;
        
        
        if(movement.y >= yMax){
            moveDown = true;
            moveUp= false;
        }

        if(movement.y <= yMin){
            moveUp = true;
            moveDown=false;
        }

        if (moveUp)
        {
            movement.y += animSpeed * Time.deltaTime;
        }
        else
        {
            movement.y -= animSpeed * Time.deltaTime;
        }

        gameObject.transform.position = movement;
    }
}
