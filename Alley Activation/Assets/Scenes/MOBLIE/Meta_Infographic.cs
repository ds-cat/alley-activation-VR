using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.InputSystem.XR;

namespace DF
{
    public class Meta_Infographic : MonoBehaviour
    {
        [SerializeField]
        public Transform main_cam;
        public RaycastHit hit;
        public LayerMask learnableObjects;
        public GameObject currentSelection;
        public objectInfo Info;
        public Collider collide;
        public Rigidbody body;
        public laser pointerLaser;
        public InputDevice leftContoller;
        public XRController rightContoller;
        public Image infoGraphic;
        public Outline outline;
        public string object_info_string;
        public bool trigger_down;
        public bool trigger_up;
        public bool displayUp;
        public menuScript menuScript;
        Unity.XR.Oculus.Input.OculusRemote remote;


        public void FixedUpdate()
        {
        
        }

        public void pointAtObject()
        {

           
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "learnable")
                    {


                        //highlight hit object
                        currentSelection = hit.transform.gameObject;
                        outline = currentSelection.GetComponent<Outline>();
                        Info = currentSelection.GetComponent<objectInfo>();
                        object_info_string = Info.info;
                        outline.enabled = true;

                    }
                }


            





        }

        private void Start()
        {
            // right_hand = right_hand.parent.GetComponentInChildren<Hand>();
            List<InputDevice> devices = new List<InputDevice>();
            InputDevices.GetDevices(devices);
            Debug.Log(devices);
            foreach (var item in devices)
            {
                Debug.Log(item.name);
            }

           
            //infoGraphic.sprite = null;
            //i/nfoGraphic.color = new Vector4(0, 0, 0, 0);
            //menuScript = GetComponentInChildren<menuScript>();
            //pointer.pointer;
        }

        public void TriggerUp()
        {

            trigger_down = false;
          

        }
        public void TriggerDown()
        {

            //start pointing
            trigger_down = true;


        }

        public void closeInfoGraph()
        {
            infoGraphic.sprite = null;
            infoGraphic.color = infoGraphic.color = new Vector4(0, 0, 0, 0);
            outline.enabled = false;
            currentSelection = null;
            displayUp = false;
        }


        public void Update()
        {
            if (false)
            {
                if (menuScript.menuBackround.enabled == false)
                {
                    if (trigger_down)
                    {

                        if (displayUp)
                        {
                            //close dispaly infographic
                            closeInfoGraph();
                        }
                        else
                        {
                            pointAtObject();
                        }

                    }
                    else if (currentSelection != null)
                    {
                        //display infographic
                        infoGraphic.color = Color.white;
                        infoGraphic.sprite = Info.image;
                        displayUp = true;
                    }
                    else
                    {
                        if (outline != null)
                            outline.enabled = false;
                    }
                }
            }
        }
    }
}



