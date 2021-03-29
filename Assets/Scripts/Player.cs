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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            MakeSphere();
            Debug.Log("Chracter changed");
        }
    }
    void MakeSphere()
    {
        //close character components
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        //open sphere components
        changedSphere.gameObject.GetComponent<MeshRenderer>().enabled = true;
        changedSphere.gameObject.GetComponent<SphereCollider>().enabled = true;
    }
}
