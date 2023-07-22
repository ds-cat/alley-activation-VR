using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;
using Valve.VR.Extras;
using UnityEngine.UI;

namespace DF
{
    public class PointAtObject : MonoBehaviour
    {
        public SteamVR_Action_Boolean lineOut;
        public SteamVR_Input_Sources handType;
        public Transform right_hand;

        public Transform left_hand;
        public Transform main_cam;

        public RaycastHit hit;
        public LayerMask learnableObjects;

        public GameObject currentSelection;
        public objectInfo Info;
        public SteamVR_LaserPointer pointer;
        public Collider collider;
        public Rigidbody body;
        public laser pointerLaser;



        public Image infoGraphic;


        public Outline outline;
        public string object_info_string;

        public bool trigger_down;
        public bool trigger_up;

        public bool displayUp;

        public menuScript menuScript;



        public void pointAtObject()
        {
          
            Physics.Raycast(right_hand.position, right_hand.transform.forward, out hit, learnableObjects);
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

           
               


        }

        private void Start()
        {
           // right_hand = right_hand.parent.GetComponentInChildren<Hand>();
            lineOut.AddOnStateDownListener(TriggerDown, handType);
            lineOut.AddOnStateUpListener(TriggerUp, handType);
            pointer.thickness = 0.00f;
            infoGraphic.sprite = null;
            infoGraphic.color = new Vector4(0,0, 0, 0);
            menuScript = GetComponentInChildren<menuScript>();
            //pointer.pointer;
        }

        public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {

            trigger_down = false;
            pointer.thickness = 0.00f;

        }
        public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {

            //start pointing
            trigger_down = true;
            pointer.thickness = 0.002f;

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



