using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BookShelf : MonoBehaviour
{
    public Transform bookShelf;
    public float timeDelay;
    public float range;
    public float totalBook;
    private float currentBook;
    public void CheckLock()
    {
        currentBook++;
        if (currentBook == totalBook)
        {
            OpenDoor();
        }
    }
    public void OpenDoor()
    {
        StartCoroutine(OpenDoorCouroutine());
    }
     IEnumerator OpenDoorCouroutine()
    {
        yield return new WaitForSeconds(timeDelay);
        bookShelf.DOLocalMoveX(range, 2);
    }
}
