using Cinemachine;
using DF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectObject : MonoBehaviour
{
    public InputManager inputManager;

    public bool isInDefaultState = true;
    public bool isInMenuState = false;
    public bool isInMoveState = false;
    public bool isInInfoState = false;

    public CinemachineInputProvider cinemachine;


    public FirstMenu firstMenu;

    public Image menu;
    public Image infoGraphic;

    public GameObject selectedObject;
    Rigidbody body;
    Outline outline;

    public Camera cam;

    public float moveSpeed;
    public float rotateSpeed;

    //
    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        firstMenu = GetComponent<FirstMenu>();
        cinemachine = FindAnyObjectByType<CinemachineInputProvider>();
        infoGraphic.enabled = false;
    }

    public void OpenMenu()
    {
        firstMenu.closeMenu();
        isInMenuState = true;
        isInDefaultState = false;
        menu.enabled = true;
        

    }

    public void CloseMenu()
    {
        isInMenuState = false;
        isInDefaultState = true;
        if(outline  != null)
        {
            outline.enabled = false;
        }
        
        menu.enabled = false;
        infoGraphic.enabled = false;
    }

    public void StartMove()
    {
        isInMenuState = false;
        isInMoveState = true;
        menu.enabled = false;
    }

    public void StopMove()
    {
        isInMoveState= false;

        CloseMenu();
    }

    public void StartInfo()
    {
        isInMenuState = false;
        isInInfoState = true;
        infoGraphic.sprite = selectedObject.GetComponent<objectInfo>().image;
        infoGraphic.enabled = true;
        menu.enabled = false;
    }

    public void StopInfo()
    {
        isInInfoState= false;
        infoGraphic.enabled = false;
        CloseMenu() ;
    }

    public void handleObjectMove()
    {
        
        if (inputManager.inputs.Player.moveup.WasPressedThisFrame())
        {
            body.transform.position += (Vector3.up * Time.deltaTime * moveSpeed);
        }
        if(inputManager.inputs.Player.movedown.WasPressedThisFrame())
        {
            body.transform.position += (Vector3.down * Time.deltaTime * moveSpeed);
        }
        Vector2 temp = inputManager.inputs.Player.move.ReadValue<Vector2>();
        Vector3 moveDir = new Vector3(temp.x, 0 , temp.y);
        moveDir= this.transform.right * moveDir.x + this.transform.forward * moveDir.z;
        body.transform.position += (moveDir * Time.deltaTime * moveSpeed) ;
        temp = inputManager.inputs.Player.look.ReadValue<Vector2>();
        Vector3 rotateDir = new Vector3(temp.y, 0, temp.x);
        Vector3 curretROT = body.rotation.eulerAngles;
        rotateDir.x += rotateDir.x * rotateSpeed * Time.deltaTime;
        rotateDir.z += rotateDir.z * rotateSpeed * Time.deltaTime;
        curretROT += rotateDir;
        Quaternion rot = Quaternion.Euler(curretROT);
        body.rotation = (rot);
        Debug.Log(rot);

    }
    // Update is called once per frame
    void Update()
    {
        if (isInDefaultState)
        {
            if(cinemachine.enabled == false)
            cinemachine.enabled = true;
        }
        else
        {
            if(cinemachine.enabled == true)
            cinemachine.enabled = false;
        }
        if (inputManager.inputs.Player.scan.WasPressedThisFrame())
        {
            if (isInDefaultState)
            {
                //when button is pressed, shoot out ray from center of screen
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.tag == "learnable" || hit.collider.tag == "grabable")
                    {
                        Debug.Log("ding");
                        selectedObject = hit.collider.gameObject;
                        body = selectedObject.GetComponent<Rigidbody>();
                        outline = selectedObject.GetComponent<Outline>();
                        outline.enabled = true;
                        body.useGravity = false;
                        body.constraints = RigidbodyConstraints.FreezeAll;
                        OpenMenu();
                    }
                }
                
            }
            else
            {
                //cancel
                if (isInMoveState)
                {
                    StopMove();
                }
                else if (isInInfoState)
                {
                    StopInfo();
                }
                else if (isInMenuState)
                {
                    CloseMenu();
                }
            }
            
        }
        if (isInMenuState)
        {
            if (inputManager.inputs.Player.cycleleft.WasPressedThisFrame())
            {
                StartMove();
                //move
            }

            if(inputManager.inputs.Player.info.WasPressedThisFrame())
            {
               
                StartInfo();
                //infograpic
            }

        }
        if(isInMoveState)
        {
            handleObjectMove();
        }

        

    }
}
