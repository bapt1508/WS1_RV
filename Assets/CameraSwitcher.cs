using intervales.utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitcher : MonoBehaviour
{

    public GameObject Camera;
    public GameObject flycam;
    private FlyCam flycamScript;
    private HandleWaypoint handleWaypoint;
    private Camera FlyCamera;
    public Camera XRcamera;
    private bool usingCameraBase = true;
    

    void Start()
    {
        
        flycamScript = flycam.GetComponent<FlyCam>();
        handleWaypoint = flycam.GetComponent<HandleWaypoint>();
        FlyCamera = Camera.GetComponent<Camera>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) 
        {
            if (usingCameraBase)
            {
                XRcamera.tag = "MainCamera";
                FlyCamera.tag = "Untagged";
                usingCameraBase = !usingCameraBase;
                Camera.SetActive(usingCameraBase);
            }
            else
            {
                XRcamera.tag = "Untagged";
                FlyCamera.tag = "MainCamera";
                usingCameraBase = !usingCameraBase;
                Camera.SetActive(usingCameraBase);
            }
            
            flycamScript.enabled = usingCameraBase;
            handleWaypoint.enabled = usingCameraBase;
            
        }
    }
}
