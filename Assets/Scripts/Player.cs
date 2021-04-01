using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public GameObject changedSphere; // after finishLine our character will be sphere
    public GameObject playerMesh;
    public bool isSphere;
    
    private void Start()
    {
    }
    private void Update()
    {

        
        //Rotates the sphere 
        if (isSphere)
        {
            changedSphere.transform.Rotate(3,0,0);
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Finish")
        {
            MakeSphere();
            Debug.Log("Chracter changed");
        }
        
        // when player gets pixels our character will scale
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
        //Disables the body mesh and collider
        playerMesh.GetComponent<SkinnedMeshRenderer>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        
        //Activates the sphere mesh and collider
        changedSphere.GetComponent<SphereCollider>().enabled = true;
        changedSphere.GetComponent<MeshRenderer>().enabled = true;
        isSphere = true;

    }
}
