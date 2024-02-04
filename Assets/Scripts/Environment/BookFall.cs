using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BookFall : MonoBehaviour,ICollisionDrone
{
    public Animator animator;
    public Rigidbody rb_Light;
    public Vector3 direction;
    public float time=5;
   
    public void OnConllisonDrone()
    {
        Vector3 localPos = transform.InverseTransformPoint(Player.ins.droneController.transform.position);
        if (localPos.z > 0) return;
        animator.enabled = true;
    }
    public void FinishAnim()
    {
        rb_Light.AddForce(direction);
        StartCoroutine(SetIsKinematic());
       
    }
    IEnumerator SetIsKinematic()
    {
        yield return new WaitForSeconds(time);
        rb_Light.isKinematic = true;
    }
   
}
