using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ToggleCamera : MonoBehaviour
{
    private ARCameraManager aRCameraManager;
    private bool isFrontCamera = false;
    void Start()
    {
        aRCameraManager = FindObjectOfType<ARCameraManager>();
    }
    public void ToggleCameraFacing()
    {
        isFrontCamera = !isFrontCamera;
        aRCameraManager.requestedFacingDirection = isFrontCamera
        ? CameraFacingDirection.User
        : CameraFacingDirection.World;
        
        

    }
}
