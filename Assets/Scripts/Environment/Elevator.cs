using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    
    public List<Transform> target;
    public Door door;
    public float duration;
    public Transform groundTrans;
  
    public void MoveToTarget(int index)
    {
        StartCoroutine(Moverment(index));
    }
    IEnumerator Moverment(int index)
    {
        float time = 0;
        float totaltime = Vector3.Distance(groundTrans.position, target[index].position) / duration;
        Vector3 pos = groundTrans.transform.position;
        while (time < totaltime)
        {
            
            time += Time.deltaTime;
            groundTrans.transform.position = Vector3.Lerp(pos, target[index].position, time / totaltime);
            yield return null;
        }
       door.OpenDoor();
    }
   
}

