using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public GameObject colliding;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "learnable")
        {
            colliding = other.gameObject;
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == colliding)
        {
            colliding = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
