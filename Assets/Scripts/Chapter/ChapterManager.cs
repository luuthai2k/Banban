using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManager : MonoBehaviour
{
    public PointManager pointManager;
    protected Player player;
    protected UIManager uiManager;
    public ItemObject itemObject;
    public float startTime;
    public float step;

    public void CheckStep()
    {
        step++;
        StepManager();
    }
    public virtual void StepManager()
    {
        
    }
}
