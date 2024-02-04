using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMonster : MonoBehaviour,ICollisionDrone
{
    public Animator animator;
    public void Attack()
    {
        animator.enabled = true;
    }
    public void OnConllisonDrone()
    {
        animator.Play("1_Enemy_Attack 1");
    }
}
