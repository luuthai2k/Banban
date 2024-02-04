using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : Item
{
    public int totalKey;
    public Collider m_collider;

    public override void Select()
    {
      
        if (GameManager.ins.itemManager.CheckItem(id, totalKey))
        {
            Success();
        }
        else
        {
            Defeat();
        }
    }
    public virtual void Success()
    {

    }
    public virtual void Defeat()
    {

    }
    public virtual void OnActive(bool isActive)
    {
        m_collider.enabled = isActive;
    }
}
