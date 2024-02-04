using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1 : ChapterManager
{
    public Elevator elevator;
  
   
    void Start()
    {
        GameManager.ins.chapterManager = this;
        player = Player.ins;
        uiManager = UIManager.ins;
        Init();
    }
    public void Init()
    {
      
        player.transform.position = pointManager.playerStartPoint.position;
        player.droneController.transform.position = pointManager.droneStartPoint.position;
        itemObject.GetRemote(pointManager.remoteStartPoint.position, pointManager.remoteStartPoint.rotation);
        uiManager.OnUI(false);
        uiManager.OnDroneControl(false);
        elevator.MoveToTarget(0);
        StartCoroutine(CouroutineCanControl());
    }
  
    public override void StepManager()
    {
        switch (step)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break; 

        }
    }
    public void SpawnBattery()
    {
        itemObject.GetBattery();
    }
    IEnumerator CouroutineCanControl()
    {
        yield return new WaitForSeconds(startTime);
        uiManager.OnUI(true);
    }
    public void Complete(float time)
    {
        StartCoroutine(CouroutineComplete(time));
    }
    IEnumerator CouroutineComplete(float time)
    {
        yield return new WaitForSeconds(time);
        uiManager.OnComplete(true);
    }

}
