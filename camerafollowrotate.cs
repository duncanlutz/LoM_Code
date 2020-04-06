using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollowrotate : MonoBehaviour
{
	public Rigidbody rb;
	public Transform target;
	
	public float forwardForce = 500f;
	public float sidewaysForce = 500f;

    // use fixedupdate because Unity prefers that
	
    void FixedUpdate()
    {
		if(Input.GetKey("w"))
		{
        rb.AddForce(0, forwardForce * Time.deltaTime, 0, ForceMode.VelocityChange);
		}
		if(Input.GetKey("s"))
		{
			rb.AddForce(0, -forwardForce * Time.deltaTime, 0, ForceMode.VelocityChange);
		}
		if (Input.GetKey("d"))
		{ 
			rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}	
		if (Input.GetKey("a"))
		{ 
			rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}	
	transform.LookAt(target);
    }
}
