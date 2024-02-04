using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/ItemsData")]
public class ItemsData : ScriptableObject
{
    public List<_Item> items = new List<_Item>();
}
[Serializable]
public struct _Item
{
    public string namekey;
    public string namelock;
    public int id;


}