using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    public override void Select()
    {
        gameObject.SetActive(false);
        GameManager.ins.itemManager.AddItem(id,this);
    }
}
