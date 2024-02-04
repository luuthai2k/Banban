using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    public GameObject playerControl;
    public GameObject drone;
    public Joystick joystick;
    public PickUp pickUp;
    public Teleport teleport;
    public bool isJump;
    public bool isDrone;
    public bool isSprint;
    public bool isSitdown;
    [HideInInspector]public bool canControlDrone;
   
    public void OnJump(bool isActive)
    {
        isJump = isActive;
    }
    public void OnPickUp(bool isActive)
    {
        pickUp.gameObject.SetActive(isActive);
    }
    public void OnDrone()
    {
        if (!canControlDrone)
        {
            isDrone = false;
            return;
        }
        isDrone = !isDrone;
        
    }
    public void OnSprint()
    {
        isSprint = !isSprint;
    }
    public void OnSitDown()
    {
        isSitdown = !isSitdown;
    }
    public void DroneControllable()
    {
        drone.SetActive(true);
        teleport.gameObject.SetActive(true);
    }

}
