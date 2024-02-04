using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static PointManager ins;
    public Transform playerStartPoint;
    public Transform droneStartPoint;
    public Transform droneTargetStartPoint;
    public Transform remoteStartPoint;
    public List<Transform> checkPoint = new List<Transform>();
    public int process;
    public List<Transform> teleportPoint = new List<Transform>();
    public int indexTeleport;
    private void Awake()
    {
        if (ins != null)
        {
            ins = null;
        }
        ins = this;
    }
  
    public void SetCheckPoint()
    {
        process++;
    }
    public void SetTeleportPoint(int i)
    {
        indexTeleport = i;
    }
    public Vector3 GetTeleportPoint()
    {
        return teleportPoint[indexTeleport].position;
    }

}
