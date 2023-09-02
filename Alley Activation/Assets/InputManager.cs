using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public FPSinputs inputs;
    private void Awake()
    {
        inputs = new FPSinputs();

    }
    private void OnEnable()
    {
        inputs.Enable();
    }
    private void OnDisable()
    {
        inputs.Disable();
    }

    public Vector2 GetMovement()
    {
        return inputs.Player.move.ReadValue<Vector2>();
    }

    public Vector2 GetLook() 
    {
        return inputs.Player.look.ReadValue<Vector2>();
    }

    public bool Jumped()
    {
        return false;
    }

}
