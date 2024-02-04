using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public List<GameObject> Items;
    public void GetItem(int index)
    {
        Items[index].SetActive(true);
    }
    public void GetBattery()
    {
        Items[1].SetActive(true);
        Items[2].SetActive(true);

    }
    public void GetRemote(Vector3 pos,Quaternion rot, Transform parent = null)
    {
        Items[0].SetActive(true);
        Items[0].transform.position=pos;
        transform.rotation = rot;
        Items[0].transform.parent = parent;
    }
    


}
