using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Remote : Item
{
    public UnityEvent pickUp;

    public override void Select()
    {
        transform.parent = Player.ins.handTransform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        pickUp.Invoke();
    }
}
