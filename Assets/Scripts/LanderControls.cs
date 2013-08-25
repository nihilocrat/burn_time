using UnityEngine;
using System.Collections;

public class LanderControls : MonoBehaviour
{
	public int score = 0;
	public float fuel = 10f;
	public float thrust = 10000f;
	public float turnRate = 10f;
	public ParticleSystem thrustParticles;
	public TextMesh fuelIndicator;
	public BlockMeter rescueMeter;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void Update ()
	{
		fuelIndicator.text = fuel.ToString("f1");
		rescueMeter.SetBlocks(score);
		
		if(Input.GetButton("Vertical") && Input.GetAxis("Vertical") > 0f)
		{
			if(fuel > 0f)
			{
				rigidbody.AddForce(transform.forward * thrust * Time.deltaTime);
				fuel -= Time.deltaTime;
				thrustParticles.enableEmission = true;
				if(!audio.isPlaying)
				{
					audio.Play();
				}
			}
			else
			{
				thrustParticles.enableEmission = false;
				audio.Stop();
			}
		}
		else
		{
			thrustParticles.enableEmission = false;
			audio.Stop();
		}
		
		if(Input.GetButton("Horizontal"))
		{
			//rigidbody.AddTorque(0f, 0f, -Input.GetAxis("Horizontal") * turnRate * Time.deltaTime);
			transform.Rotate(0f, Input.GetAxis("Horizontal") * turnRate * Time.deltaTime, 0f);
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
		collision.gameObject.SendMessage("OnPickup", this, SendMessageOptions.DontRequireReceiver);
	}
	
	void OnTriggerEnter(Collider other)
	{
		other.gameObject.SendMessage("OnPickup", this, SendMessageOptions.DontRequireReceiver);
	}
}
