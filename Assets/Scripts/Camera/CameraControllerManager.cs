using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControllerManager : MonoBehaviour
{
    public CameraControl cameraControl;
    public CameraInputHandle m_cameraInputHandle;
    private float _mouseVerticalValue;
    public float sensitivity;
   
    void Update()
    {
       
#if UNITY_EDITOR
        //MouseVerticalValue = Input.GetAxis("Mouse Y");
        //cameraTransform.root.rotation = Quaternion.Euler(0, cameraTransform.root.localRotation.eulerAngles.y + Input.GetAxis("Mouse X") * sensitivity, 0);
        cameraControl.CamControl(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
#else
        //MouseVerticalValue = m_cameraInputHandle.m_playerTouchVectorOutput.y;
        //cameraTransform.root..rotation = Quaternion.Euler(0, cameraTransform.root.localRotation.eulerAngles.y + -m_cameraInputHandle.m_playerTouchVectorOutput.x* sensitivity, 0);
        cameraControl.CamControl(m_cameraInputHandle.m_playerTouchVectorOutput.x, m_cameraInputHandle.m_playerTouchVectorOutput.y);
#endif
        //cameraTransform.localRotation = Quaternion.Euler(-MouseVerticalValue * sensitivity, 0, 0);
    }
    public void ChangeCamera(CameraControl _cameraControl)
    {
        cameraControl.m_camera.enabled = false;
        cameraControl = _cameraControl;
        cameraControl.m_camera.enabled = true;
    }
    

}
