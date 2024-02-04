using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationButton : Item
{
    public Collider m_collider;
    public  RotationLock rotationLock;

    public override void Select()
    {
        rotationLock.RotationLight(id);
       
    }


    public void OnActive(bool isActive)
    {
        m_collider.enabled = isActive;
    }
}
