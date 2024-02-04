using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBar : Lock
{
    public Rigidbody rb;
    public WoodenFence woodenFence;

    public override void Success()
    {
        rb.isKinematic = false;
        Invoke("FinishAnim", 5);
        woodenFence.ChecKDisable();


    }
    public override void Defeat()
    {
        base.Defeat();
    }
  
}
