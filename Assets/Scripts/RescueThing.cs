using UnityEngine;
using System.Collections;

public class RescueThing : MonoBehaviour
{
	public GameObject effect;
	public int addScore = 0;
	public float addFuel = 0f;
	
	void Start()
	{
		if(addFuel > 0)
		{
			GetComponentInChildren<TextMesh>().text = addFuel.ToString();
		}
	}
	
	void OnPickup(LanderControls lander)
	{
		lander.score += addScore;
		lander.fuel += addFuel;
		
		if(effect != null)
		{
			Instantiate(effect, transform.position, transform.rotation);
		}
		
		Destroy(gameObject);
	}
}
