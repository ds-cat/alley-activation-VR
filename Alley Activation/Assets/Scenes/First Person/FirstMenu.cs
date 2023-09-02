using DF;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FirstMenu : MonoBehaviour
{
    //object in left slot
    public spawnableProp objectInLeft;
    //object in middle slot
    public spawnableProp objectInCenter;
    //object in right slot
    public spawnableProp objectInRight;

    public Transform spawn_location;

    //all objects array
    public spawnableProp[] allObjects;
    //current middle object id
    public int arrayIDLeft;
    public int arrayIDcenter;
    public int arrayIDRight;


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

    public InputManager inputManager;

    //arrow left
    //arrow right

    //current selectionID (0,1,2,3,4) 0 is left arrow, 4 is right arrow
    public int selectionID;

    public void MenuUp()
    {
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
        }
        else
        {
            closeMenu();
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
        GameObject newObj = Instantiate(prop.propGameobject);
        newObj.transform.position = spawn_location.position;
        newObj.transform.rotation = spawn_location.rotation;

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

        arrayIDLeft = arrayIDcenter;
        arrayIDcenter = arrayIDRight;
        if (arrayIDRight == allObjects.Length - 1)
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
        arrayIDRight = arrayIDcenter;
        arrayIDcenter = arrayIDLeft;
        if (arrayIDLeft == 0)
        {
            arrayIDLeft = allObjects.Length - 1;
        }
        else
        {
            arrayIDLeft--;
        }
    }


    void Start()
    {
        arrayIDLeft = 0;
        arrayIDcenter = 1;
        arrayIDRight = 2;
        selectionID = 2;
        closeMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if(inputManager.inputs.Player.menu.WasPressedThisFrame())
        {
            //open/close menu
            openMenu();
        }

        if(inputManager.inputs.Player.cycleright.WasPressedThisFrame())
        {
            //cycle right
            cycleRight();
        }

        if(inputManager.inputs.Player.cycleleft.WasPressedThisFrame())
        {
            //cycle left
            cycleLeft();
        }

        if(inputManager.inputs.Player.select.WasPressedThisFrame())
        {
            //spawn object
            selectCurrentSelection();
        }
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

