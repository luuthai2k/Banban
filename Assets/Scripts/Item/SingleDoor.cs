using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDoor : Item
{
    public Animator animator;
    public Collider m_collider;
    public override void Select()
    {
        OpenDoor();
    }
    public void OpenDoor()
    {
        animator.enabled = true;
        m_collider.enabled = false;
    }
}
