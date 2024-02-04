using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == null) return;
        if (other.transform.parent.TryGetComponent<ICollisionDrone>(out var collision))
        {
            collision.OnConllisonDrone();
        }
    }
}
