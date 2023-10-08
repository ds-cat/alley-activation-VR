
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using static UnityEngine.XR.Interaction.Toolkit.InputHelpers;

namespace DF
{
    public class Meta_Menu_Script : MonoBehaviour
    {
        public Moble_inputs inputs;

        public ActionBasedControllerManager controllerManager;
        public void bruh()
        {
            Application.Quit();
        }

        // Start is called before the first frame update
        public XRController controllerRight;
        public bool dud;
        public XRController controllerLeft;
        public InputHelpers.Button Abutton;
        public InputHelpers.Button Bbutton;
        public InputHelpers.Button R_stickClick;

        public InputHelpers.Button L_stickClick;
        //object in left slot
        public spawnableProp objectInLeft;
        //object in middle slot
        public spawnableProp objectInCenter;
        //object in right slot
        public spawnableProp objectInRight;

        //all objects array
        public spawnableProp[] allObjects;
        //current middle object id
        public int arrayIDLeft;
        public int arrayIDcenter;
        public int arrayIDRight;
        
        public GameObject objec_spawn_loc;

        public Image menuBackround;
        public Image leftArrow;
        public Image rightArrow;
        public Image selectionIndicator;

        public Image leftPropImage;
        public Image rightPropImage;
        public Image centerPropImage;

        public TextMeshProUGUI leftText; 
        public TextMeshProUGUI rightText;
        public TextMeshProUGUI centerText;

        //arrow left
        //arrow right

        //current selectionID (0,1,2,3,4) 0 is left arrow, 4 is right arrow
        public int selectionID;

        public void MenuUp()
        {
            Debug.Log("ding");
            openMenu();
        }
        public void MenuDown()
        {
            //closeMenu();
        }

        public void selectUp()
        {
            selectCurrentSelection();
        }

        public void selectDown()
        {
            //selectCurrentSelection();
        }

        public void cycleLeft()
        {
            moveSelectionLeft();
        }

        public void cycleRight()
        {
            moveSelectionRight();
        }

        public void openMenu()
        {
         
            if (menuBackround.enabled != true)
            {
                menuBackround.enabled = true;
                leftArrow.enabled = true;
                rightArrow.enabled = true;
                selectionIndicator.enabled = true;
                leftPropImage.enabled = true;
                rightPropImage.enabled = true;
                centerPropImage.enabled = true;
                leftText.enabled = true;
                rightText.enabled = true;
                centerText.enabled = true;
                //pointAt.closeInfoGraph();
                selectionID = 2;
                controllerManager.smoothMotionEnabled = false;
                leftHand.enableInputActions = false; rightHand.enableInputActions = false;
                rightHand.enabled=false;
            }
            else
            {
                closeMenu();
                leftHand.enableInputActions = true; rightHand.enableInputActions = true;
                rightHand.enabled = true;
            }
        }

        public void closeMenu()
        {
            menuBackround.enabled = false;
            leftArrow.enabled = false;
            rightArrow.enabled = false;
            selectionIndicator.enabled = false;
            leftPropImage.enabled = false;   
            rightPropImage.enabled = false;
            centerPropImage.enabled = false;
            leftText.enabled = false;
            rightText.enabled = false;
            centerText.enabled = false;
            selectionID = 2;
           // controllerManager.smoothMotionEnabled = true;
        }

        public void selectCurrentSelection()
        {
            switch (selectionID)
            {
                case 0:
                    shiftLeft();
                    break;
                case 1:
                    //spawn object in slot 1
                    spawnObject(objectInLeft);
                    break;
                case 2:
                    //spawn object in slot 2
                    spawnObject(objectInCenter);
                    break;
                case 3:
                    //spawn object in slot 3
                    spawnObject(objectInRight);
                    break;
                case 4:
                    shiftRight();
                    break;


            }
        }

        public void spawnObject(spawnableProp prop)
        {
            if (menuBackround.enabled == false)
            {
                return;
            }
            Vector3 pos = objec_spawn_loc.transform.position;
            Vector3 dir = objec_spawn_loc.transform.forward;
            Quaternion rot = objec_spawn_loc.transform.rotation;
            Vector3 spawnPos = pos + dir;
            GameObject newObj  = Instantiate(prop.propGameobject);
            newObj.transform.position = spawnPos;
            newObj.transform.rotation = rot;
        }

        public void moveSelectionRight()
        {
            if (selectionID == 4)
            {
                return;
            }
            else
            {
                selectionID++;
            }
            switch(selectionID)
            {
                case 0:
                    selectionIndicator.transform.position = leftArrow.transform.position;
                    break;
                    case 1:
                    selectionIndicator.transform.position = leftPropImage.transform.position;
                    break;
                    case 2:
                    selectionIndicator.transform.position = centerPropImage.transform.position;
                    break;
                    case 3:
                    selectionIndicator.transform.position = rightPropImage.transform.position;
                    break;
                    case 4:
                    selectionIndicator.transform.position = rightArrow.transform.position;
                    break;
            }
        }

        public void moveSelectionLeft()
        {
            if (selectionID == 0)
            {
                return;
            }
            else
            {
                selectionID--;
            }
            switch (selectionID)
            {
                case 0:
                    selectionIndicator.transform.position = leftArrow.transform.position;
                    break;
                case 1:
                    selectionIndicator.transform.position = leftPropImage.transform.position;
                    break;
                case 2:
                    selectionIndicator.transform.position = centerPropImage.transform.position;
                    break;
                case 3:
                    selectionIndicator.transform.position = rightPropImage.transform.position;
                    break;
                case 4:
                    selectionIndicator.transform.position = rightArrow.transform.position;
                    break;
            }
        }


        public void shiftLeft()
        {
            //move 
            
            arrayIDLeft= arrayIDcenter;
            arrayIDcenter = arrayIDRight;
            if (arrayIDRight == allObjects.Length-1)
            {
                arrayIDRight = 0;
            }
            else
            {
                arrayIDRight++;
            }
        }

        public void shiftRight()
        {
            arrayIDRight= arrayIDcenter;
            arrayIDcenter= arrayIDLeft;
            if (arrayIDLeft == 0)
            {
                arrayIDLeft = allObjects.Length-1; 
            }
            else
            {
                arrayIDLeft--;
            }
        }

        private void Awake()
        {
            inputs = new Moble_inputs();
            inputs.Enable();
        }
        void Start()
        {
            arrayIDLeft = 0;
            arrayIDcenter = 1;
            arrayIDRight = 2;
            selectionID = 2;
            closeMenu();
            
        }

        public float timer = 0f;
        public bool movingRight;
        public XRController rightHand;
        public XRController leftHand;

        // Update is called once per frame
        void Update()
        {
            if(inputs.meta.closeGame.WasPressedThisFrame())
            {
                bruh();
            }
            if(inputs.meta.menu.WasPressedThisFrame())
            {
                
            }
            if(inputs.meta.Abutton.WasPressedThisFrame())
            {
                selectCurrentSelection();
            }
            if(inputs.meta.Bbutton.WasPressedThisFrame())
            {
                openMenu();
            }

            if (menuBackround.enabled)
            {
               
                Vector2 stick_input = inputs.meta.stick.ReadValue<Vector2>();

                if (stick_input.x > 0.1)
                {
                    if (movingRight == false)
                    {
                        timer = 0f;
                    }
                    timer = Time.deltaTime + timer;
                    movingRight = true;
                }
                if (stick_input.x < 0.1f)
                {
                    if (movingRight == true)
                    {
                        timer = 0f;
                    }
                    timer = Time.deltaTime + timer;
                    movingRight = false;
                }
                if (stick_input.x == 0)
                {
                    timer = 0;
                }
                if (timer > 0.25f)
                {
                    //move selection
                    if (movingRight == true)
                    {
                        moveSelectionRight();
                    }
                    else
                    {
                        moveSelectionLeft();
                    }
                    timer = 0f;
                }

            }
            else
            {
                timer = 0;
            }


            //controllerRight.inputDevice.IsPressed(rightStick, out stick);
            //controllerRight.inputDevice.IsPressed()

            objectInRight = allObjects[arrayIDRight];
            objectInLeft = allObjects[arrayIDLeft];
            objectInCenter = allObjects[arrayIDcenter];
            leftPropImage.sprite = objectInLeft.propIcon;
            rightPropImage.sprite = objectInRight.propIcon;
            centerPropImage.sprite = objectInCenter.propIcon;
            leftText.text = objectInLeft.propName;
            rightText.text = objectInRight.propName;
            centerText.text = objectInCenter.propName;

        }
    }
}
