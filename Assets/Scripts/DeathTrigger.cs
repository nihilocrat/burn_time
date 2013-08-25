using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour
{
	public LanderControls lander;
	public GameObject fireEffect;
	public GameObject boomEffect;
	
	private bool dying = false;
	
	void OnCollisionEnter(Collision collision)
	{
		OnTriggerEnter(collision.collider);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == lander.gameObject || other.isTrigger)
		{
			return;
		}
		
		if(!dying)
		{
			lander.score = 0;
			
			var fire = Instantiate(fireEffect, transform.position, transform.rotation) as GameObject;
			fire.transform.parent = lander.transform;
			
			Invoke("OnKill", 2.0f);
			dying = true;
		}
		else
		{
			OnKill();
		}
	}
	
	void OnKill()
	{
		Destroy(lander.gameObject);
		Instantiate(boomEffect, transform.position, transform.rotation);
		
		LanderGameDirector.Instance.SendMessage("OnGameOver", false);
	}
}
