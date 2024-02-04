using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenFence : MonoBehaviour
{
    public int totalBar;
    protected int currenBAr;
    public Collider m_collider;
    public void ChecKDisable()
    {
        currenBAr++;
        if (currenBAr == totalBar)
        {
            m_collider.enabled = false;
        }
    }
}
