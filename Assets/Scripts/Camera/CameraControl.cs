using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraControl : MonoBehaviour
{
    public Camera m_camera;
    public float maxVerticalAngle;
    public float maxHorizontalAngle=0;
    public float sensitivity;
    private float _mouseVerticalValue;
    [HideInInspector]public float tilting;
    public float MouseVerticalValue
    {
        get => _mouseVerticalValue;
        set
        {
            if (value == 0) return;

            float verticalAngle = _mouseVerticalValue + value;
            verticalAngle = Mathf.Clamp(verticalAngle, -maxVerticalAngle, maxVerticalAngle);
            _mouseVerticalValue = verticalAngle;
        }
    }
    public virtual void CamControl(float x,float y)
    {
        MouseVerticalValue = y;
        transform.parent.rotation = Quaternion.Euler(0, transform.parent.localRotation.eulerAngles.y + x * sensitivity, 0);
        transform.localRotation = Quaternion.Euler(-MouseVerticalValue * sensitivity, 0, 0);
       
    }
    public void CameShake()
    {
        transform.DOShakePosition(1f, new Vector3(1, 0, 1), 5);
        transform.DOShakeRotation(1f, new Vector3(-15, 0, -30),5);
        //transform.DOShakeRotation(1f, 5);
    }
}
