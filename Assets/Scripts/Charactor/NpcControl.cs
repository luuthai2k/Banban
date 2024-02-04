using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcControl : MonoBehaviour
{
    public Animator animator;
    public float speed=5;
    public float turnCalmVelocity=1;
    public NavMeshAgent agent;
    public List<Transform> targetTransforms = new List<Transform>();
    public Vector3 targetPoint;
    public Quaternion targetRot;
    private float forward;
   
    public void MoveToTarget(int index)
    {

        targetPoint = targetTransforms[index].position;
        agent.SetDestination(targetPoint);
        StartCoroutine(MoveCouroutine(false));
    }
    public void MoveToTargetAndRotate(int index)
    {
        targetPoint = targetTransforms[index].position;
        targetRot = targetTransforms[index].rotation;
        agent.SetDestination(targetPoint);
        StartCoroutine(MoveCouroutine());
    }
    IEnumerator MoveCouroutine(bool isrotation=true)
    {
       
        agent.speed = this.speed;
        bool ismove = true;
        while (ismove)
        {
            yield return new WaitForSeconds(0.2f);
            forward = Mathf.Clamp01(agent.velocity.magnitude);
            animator.SetFloat(Constant.Forward, forward);
            if (agent.velocity.magnitude==0) 
            {
                ismove = false;
            }
          
            
        }
        if (isrotation)
        {
            StartCoroutine(RotationCouroutine());
        }
       
    }
    IEnumerator RotationCouroutine()
    {
        float time = 0;
        Quaternion rot = transform.rotation;
        while (time< turnCalmVelocity)
        {
            time += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(rot, targetRot, time / turnCalmVelocity);
            animator.SetFloat(Constant.Forward, 1- (time / turnCalmVelocity));
            Debug.Log(time);
            yield return null;
        }
    }


}
