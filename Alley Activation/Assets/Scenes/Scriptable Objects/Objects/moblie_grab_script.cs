using DF;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class moblie_grab_script : MonoBehaviour
{
    bool tracking = false;
    public GameObject righthand;
    public Meta_Infographic graphic;
    public void trackLocation()
    {
        Debug.Log("trakcing");
        tracking = true;
        graphic.trackedObject = this.transform;
    }

    public void stop() 
    {
        tracking = false;
        graphic.trackedObject = null;
    }
    public objectInfo object_info;
    public void Start()
    {
        graphic = FindObjectOfType<Meta_Infographic>();

        // SendToInfographic();
        righthand = GameObject.FindGameObjectsWithTag("righthand").First();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
