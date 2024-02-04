using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickLock : MonoBehaviour,ICollisionDrone
{
    public UnityEvent Success;
    public bool isActive;
    public void OpenDoor()
    {
        Success.Invoke();
    }
    public void OnConllisonDrone()
    {
        if (!isActive) return;
        OpenDoor();
    }
    public void SetActive(bool _isActive) 
    {
        isActive = _isActive;
    }
}
