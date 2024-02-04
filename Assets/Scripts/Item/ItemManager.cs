using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemManager : MonoBehaviour
{
   
    public List<int> items = new List<int>();
    public List<ListItems> listItems = new List<ListItems>();
    private ListItems listItem;
    public bool CheckItem(int id, float total)
    {
        if (items.Count  < id) return false;
        if (items[id] >= total) return true;
        return false;
    }
    public void AddItem(int id,Item item)
    {
        if (items.Count-1 < id)
        {
            int n = id - items.Count + 1;
            for(int i = items.Count; i <= id; i++)
            {
                items.Add(0);
                listItems.Add(listItem);
            }
        }
        items[id]++;
        listItems[id].items.Add(item);
    }
    public void RemoveItem(int id)
    {
        items[id]--;
        listItems[id].items.RemoveAt(0);
    }

}
[Serializable]
public struct ListItems
{
  
    public List<Item> items;


}


