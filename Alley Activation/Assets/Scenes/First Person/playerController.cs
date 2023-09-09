using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public InputManager InputManager;
    public selectObject select;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public Transform cameraTrans;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        InputManager = GetComponent<InputManager>();
        select = GetComponent<selectObject>();
        //cameraTrans = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void HandleMove()
    {
        if (select.isInDefaultState)
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 movement = InputManager.GetMovement();
            Vector3 move = new Vector3(movement.x, 0, movement.y);
            Vector3 look = InputManager.GetLook();
            Vector3 Rot = new Vector3(transform.eulerAngles.x, cameraTrans.transform.eulerAngles.y, transform.eulerAngles.z);
            transform.rotation = Quaternion.Euler(Rot);
            move = transform.right * move.x + transform.forward * move.z;
            move.y = 0;
            controller.Move(move * Time.deltaTime * playerSpeed);

            //if (move != Vector3.zero)
            //{
            //    gameObject.transform.forward = move;
            // }

            // Changes the height position of the player..
            if (InputManager.Jumped() && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }

    void Update()
    {
        HandleMove();  
    }
}
