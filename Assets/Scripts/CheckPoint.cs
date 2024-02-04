using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class CheckPoint : MonoBehaviour
{
    public UnityEvent enter;
    public UnityEvent exit;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 localPos = transform.InverseTransformPoint(other.transform.position);
            if (localPos.z > 0)
            {
                enter.Invoke();
                Debug.Log("enter");
            }
            else
            {
                exit.Invoke();
                Debug.Log("exit");
            }
        }
    }
}
