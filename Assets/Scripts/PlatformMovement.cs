using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
	public int range = 10;
	public Transform platform;
	public bool isActive;
	public float speed;
	private float time;
	public Rigidbody rb;
    public void Start()
    {
		time = ( platform.position.x-(transform.position.x-range / 2) );
    }

    void Update()
	{
       
        if (!isActive) return;

		platform.position = new Vector3(transform.position.x + Mathf.PingPong(time, range) - range / 2f, transform.position.y, transform.position.z);
		//rb.MovePosition(new Vector3(transform.position.x + Mathf.PingPong(time, range) - range / 2f, transform.position.y, transform.position.z));
		time += speed*Time.deltaTime;
    }
	public void SetActive(bool _isActive)
	{
		isActive = _isActive;
	}
}
