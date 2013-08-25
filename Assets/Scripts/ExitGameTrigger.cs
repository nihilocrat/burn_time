using UnityEngine;
using System.Collections;

public class ExitGameTrigger : MonoBehaviour
{
	void OnPickup(LanderControls lander)
	{
		lander.transform.DetachChildren();
		Destroy(lander.gameObject);
		LanderGameDirector.Instance.SendMessage("OnGameOver", true);
	}
}
