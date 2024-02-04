using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadadooControl : NpcControl
{
   
    public void Step1()
    {
        StartCoroutine(CouroutineStep1());
    }
    IEnumerator CouroutineStep1()
    {
        yield return new WaitForSeconds(5f);
        MoveToTargetAndRotate(1);
    }
    public void Step2()
    {
        StartCoroutine(CouroutineStep2());
    }
    IEnumerator CouroutineStep2()
    {
        yield return new WaitForSeconds(5f);
        MoveToTargetAndRotate(2);
        Step3();
    }
    public void Step3()
    {
        StartCoroutine(CouroutineStep3());
    }
    IEnumerator CouroutineStep3()
    {
        yield return new WaitForSeconds(10f);
        MoveToTargetAndRotate(3);
    }
    public void Step4()
    {
        StartCoroutine(CouroutineStep4());
    }
    IEnumerator CouroutineStep4()
    {
        yield return new WaitForSeconds(1f);
        MoveToTargetAndRotate(4);
    }
    public void Step5()
    {
        StartCoroutine(CouroutineStep5());
    }
    IEnumerator CouroutineStep5()
    {
        yield return new WaitForSeconds(1f);
        MoveToTargetAndRotate(4);
    }
}
