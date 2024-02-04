using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Transform droneTransform;
    private PointManager pointManager;
    void Start() 
    {
        droneTransform = Player.ins.droneController.transform;
        GetPoint();
    }
    public void OnTeleport()
    {
        if (pointManager == null)
        {
            GetPoint();
        }
        droneTransform.position = pointManager.GetTeleportPoint();
    }
    public void GetPoint()
    {
        if (GameManager.ins.chapterManager != null)
        {
            pointManager = GameManager.ins.chapterManager.pointManager;
        }

    }
}
