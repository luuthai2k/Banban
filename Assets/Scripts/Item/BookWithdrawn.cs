using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BookWithdrawn : Item
{
    public Transform book;
    public BookShelf bookShelf;
    public override void Select()
    {
        book.DOLocalMove(Vector3.zero, 1);
        bookShelf.CheckLock();
    }
    public void Return()
    {

    }
}
