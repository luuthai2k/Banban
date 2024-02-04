using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
public class RotationLock : Lock
{
    public UnityEvent success;
    public List<RotationButton> buttons = new List<RotationButton>();
    public List<Line> Lines;
    public float currentLight;
    public float totalLight;
    void Start()
    {
        OnRotate(false);
    }
    public override void Success()
    {
        int r=GameManager.ins.itemManager.listItems[id].items[0].GetComponent<Light>().row;
        int c = GameManager.ins.itemManager.listItems[id].items[0].GetComponent<Light>().column;
        Lines[r].lights[c].SetActive(true);
        CheckLight();
        GameManager.ins.itemManager.RemoveItem(id);
    }
    public override void Defeat()
    {
        Debug.Log("Defeat");
    }
    public void OnRotate(bool isActive)
    {
        foreach (var button in buttons)
        {
            button.OnActive(isActive);
        }
    }
   
    public void RotationLight(int id)
    {
        OnRotate(false);
        switch (id)
        {
            case 0:
                Rotation(0,0);
                RotationLight(0, 0, 0);
                break;

            case 1:
                Rotation(0,1);
                RotationLight(0, 1, 1);
                break;

            case 2:
                Rotation(1,0);
                RotationLight(1, 0, 2);
                break;

            case 3:
                Rotation(1,1);
                RotationLight(1, 1, 3);
                break;

        }
        if (CheckLock())
        {
            success.Invoke();
        }
    }
    public void Rotation(int r, int c)
    {
        int index_rr = Lines[r].ints[c];
        int index_rc = Lines[r].ints[c+1];
        int index_cr = Lines[r+1].ints[c];
        int index_cc = Lines[r+1].ints[c+1];
        Lines[r].ints[c] = index_rc;
        Lines[r].ints[c+1] = index_cc;
        Lines[r+1].ints[c] = index_rr;
        Lines[r+1].ints[c+1] = index_cr;
    }
    public void RotationLight(int r, int c,int index)
    {
       
        GameObject light_rr = Lines[r].lights[c];
        GameObject light_rc = Lines[r].lights[c+1];
        GameObject light_cr = Lines[r+1].lights[c];
        GameObject light_cc = Lines[r+1].lights[c+1];
        Lines[r].lights[c] = light_rc;
        Lines[r].lights[c+1] = light_cc;
        Lines[r+1].lights[c] = light_rr;
        Lines[r+1].lights[c+1] = light_cr;


        Lines[r].lights[c].transform.parent = buttons[index].transform;
        Lines[r].lights[c+1].transform.parent = buttons[index].transform;
        Lines[r+1].lights[c].transform.parent = buttons[index].transform;
        Lines[r+1].lights[c+1].transform.parent = buttons[index].transform;
        buttons[index].transform.DOLocalRotate(new Vector3(0,0,90),1)
        .OnComplete(() =>
        {

            Lines[r].lights[c].transform.parent = transform;
            Lines[r].lights[c + 1].transform.parent = transform;
            Lines[r + 1].lights[c].transform.parent = transform;
            Lines[r + 1].lights[c + 1].transform.parent =transform;
            buttons[index].transform.localRotation = Quaternion.identity;
            OnRotate(true);
        });

    }
   
    public bool CheckLock()
    {
        for(int i = 0; i < Lines.Count; i++)
        {
            int index = i;
            for(int j = 0; j < Lines[i].ints.Count; j++)
            {
                if (Lines[i].ints[j] != index)
                {
                    return false;
                }
            }
        }
        OnRotate(false);
        return true;
    }
    public void CheckLight()
    {
        currentLight++;
        if (currentLight == totalLight)
        {
            OnActive(false);
            OnRotate(true);
        }
    }
}
[Serializable]
public struct Line
{
    public List<int> ints;
    public List<GameObject> lights;


}


