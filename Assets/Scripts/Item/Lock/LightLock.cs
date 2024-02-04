using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLock : Lock
{
    public GameObject Onable;
    public GameObject disable;
    public RotationLock rotationLock;
    public override void Success()
    {
        Onable.SetActive(true);
        disable.SetActive(false);
        rotationLock.CheckLight();
    }
    public override void Defeat()
    {

    }
}
