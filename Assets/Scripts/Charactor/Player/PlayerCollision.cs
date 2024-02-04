using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Player player;
    public void Start()
    {
        player = Player.ins;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeadZone")) 
        {
            player.IsDie();
        }
    }
}
