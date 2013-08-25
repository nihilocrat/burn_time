using UnityEngine;
using System.Collections;

public class GravityWell : MonoBehaviour
{
	public float pullRadius = 10f;
	public float pullForce = 100f;
	
	private float radius2;
	private Rigidbody lander;
	
	// Use this for initialization
	void Start ()
	{
		radius2 = pullRadius * pullRadius;	
		
		var landerObj = GameObject.FindGameObjectWithTag("Player") as GameObject;
		lander = landerObj.rigidbody;
	}
	
	void FixedUpdate ()
	{
		var pullVec = lander.transform.position - transform.position;
		
		if(pullVec.sqrMagnitude < radius2)
		{
			var percent = 1.0f - (pullVec.magnitude / pullRadius);
			
			lander.AddForce((-pullVec.normalized) * pullForce * percent * Time.fixedDeltaTime);
		}
	}
}
