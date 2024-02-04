using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardLock : Lock
{
    public UnityEvent success;
   
    public override void Success()
    {
        success.Invoke();
      

        
    }
    public override void Defeat()
    {
        base.Defeat();
    }
  
}
