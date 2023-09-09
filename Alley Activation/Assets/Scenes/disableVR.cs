using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR; 

public class disableVR : MonoBehaviour
{
    XRDisplaySubsystem xRDisplaySubsystem;
    // Start is called before the first frame update
    void Start()
    {
        xRDisplaySubsystem.Stop();
    }


}
