using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;
using System.Linq;

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
        public Image infoGraphic;
        public Outline outline;
        public string object_info_string;
        public bool trigger_down;
        public bool trigger_up;
        public bool displayUp;
        //public menuScript menuScript;
        Unity.XR.Oculus.Input.OculusRemote remote;
        public XRRayInteractor interactor;
         
        public AudioSource audioSource;
        public AudioClip not_found;
        public AudioClip not_learnable;
        public AudioClip learnable;

        public Transform trackedObject;
        public bool tracking;
        public Transform rightHand;
        public void startTracking()
        {
            tracking = true;
        }
        public void stopTracking() { 
            tracking = false;   
        }

        public void FixedUpdate()
        {
            if (tracking == true)
            {
                trackedObject.position = rightHand.transform.position;
                trackedObject.rotation = rightHand.transform.rotation;
            }
        }

        public void openInfoGraphic()
        {
            //IXRSelectInteractable temp = interactor.GetOldestInteractableSelected();
            //if (temp.transform.parent.gameObject.tag != null)
            //{
                //Info = currentSelection.GetComponent<objectInfo>();
                //if (Info != null)
                //{
                    audioSource.clip = not_learnable;
                    //audioSource.Play();
                    //Info = currentSelection.GetComponent<objectInfo>();
                    //currentSelection = temp.transform.parent.gameObject; ;
                    //outline = currentSelection.GetComponent<Outline>();
                    
                    //object_info_string = Info.info;
                    //outline.enabled = true;
                    
               // }
               // else
               // {
               //     audioSource.clip = not_learnable;
                //}
            //}
           // else
           // {
                //audioSource.clip = ();
           // }
            
            //display infographic
            infoGraphic.color = Color.white;
            //infoGraphic.sprite = Info.image;
            displayUp = true;
        }

     

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = not_found; audioSource.Play();   
            //infoGraphic.sprite = null;
            infoGraphic.color = new Vector4(0, 0, 0, 0);
            //menuScript = GetComponentInChildren<menuScript>();
            //pointer.pointer;
            openInfoGraphic();
            closeInfoGraph();

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
            //infoGraphic.sprite = null;
            infoGraphic.color = infoGraphic.color = new Vector4(0, 0, 0, 0);
            outline.enabled = false;
            currentSelection = null;
            displayUp = false;
        }


        public void Update()
        {
        }
    }
}



