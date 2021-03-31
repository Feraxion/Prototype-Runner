using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject changedSphere;
    private void Start()
    {
    }
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Finish")
        {
            MakeSphere();
            Debug.Log("Chracter changed");
        }
        
        // when player get pixels our character will scale
        if(col.gameObject.tag == "Pixel")
        {
            gameObject.transform.localScale += Vector3.one * 0.2f;
            Destroy(col.gameObject);
        }
        
        if (col.gameObject.tag == "Obstacle")
        {

            if (col.transform.localScale.x > gameObject.transform.localScale.x)
            {
                Destroy(gameObject);
                // Add gameover screen
            }
            else
            {
                gameObject.transform.localScale /= 1.5f;
                Destroy(col.gameObject);
                //MAYBE ADD SOME SHATTERED VERSIONS
            }
            

        }
    }
    void MakeSphere()
    {
        //close character components
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = true;
        gameObject.GetComponent<MeshFilter>().mesh = changedSphere.GetComponent<MeshFilter>().mesh;
        
        //open sphere components
        //changedSphere.gameObject.GetComponent<MeshRenderer>().enabled = true;
       // changedSphere.gameObject.GetComponent<SphereCollider>().enabled = true;
    }
}
