using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoard : Item
{
  
    public ElectricLock electricLock;
    public override void Select()
    {
        electricLock.CheckPassword(id.ToString());
    }
}
