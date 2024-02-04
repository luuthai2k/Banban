using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Item/ItemData")]
public class ItemData : ScriptableObject
{
    public List<int> items = new List<int>();
}