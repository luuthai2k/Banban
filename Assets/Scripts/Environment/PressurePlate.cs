using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public PressurePlateSystem pressurePlateSystem;
    public bool isActivate;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Constant.Charactor)&&!isActivate)
        {
            isActivate = true;
            pressurePlateSystem.CheckLock(1);
        }
        
           
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Constant.Charactor)&&isActivate)
        {
            isActivate = false;
            pressurePlateSystem.CheckLock(-1);
        }


    }

}
