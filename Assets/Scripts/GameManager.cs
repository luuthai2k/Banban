using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public LayerData layerData;
    public CameraControllerManager cameraController;
    public ItemManager itemManager;
    public ChapterManager chapterManager;
    private void Start()
    {
        if (ins != null)
        {
            ins = null;
        }
        ins = this;
        LoadChapter.ins.Loadchapter();
    }
}
