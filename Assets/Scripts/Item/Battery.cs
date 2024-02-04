using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : Item
{
  
    public override void Select()
    {
        gameObject.SetActive(false);
        GameManager.ins.itemManager.AddItem(id, this);
        if (GameManager.ins.itemManager.CheckItem(id, 2))
        {
            UIManager.ins.inputControl.DroneControllable();
            Player.ins.droneController.StartEngine(2);
        }
    }
}
