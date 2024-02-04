using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlateSystem : MonoBehaviour
{
    public UnityEvent Success;
    public UnityEvent Defeat;
    public int totalPlate;
    public int currentPlate;
  
    public void CheckLock(int value)
    {
        currentPlate += value;
        if (currentPlate == totalPlate)
        {
            Success.Invoke();
        }
        else
        {
            Defeat.Invoke();
        }
    }
   
}
