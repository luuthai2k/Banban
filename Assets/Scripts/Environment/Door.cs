using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    public Transform door_L;
    public Transform door_R;
    public float timedelay;
    public float range;
    public float duration;
    
    public void OpenDoor()
    {
        StartCoroutine(CouroutineOpenDoor());
    }
    IEnumerator CouroutineOpenDoor()
    {
        yield return new WaitForSeconds(timedelay);
        door_L.DOLocalMoveX(-range, duration);
        door_R.DOLocalMoveX(range, duration);

    }
    public void CloseDoor()
    {
        StartCoroutine(CouroutineCloseDoor());
    }
    IEnumerator CouroutineCloseDoor()
    {
        yield return new WaitForSeconds(timedelay);
        door_L.DOLocalMoveX(0, duration);
        door_R.DOLocalMoveX(0, duration);
    }
}