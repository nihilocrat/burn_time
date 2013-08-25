using UnityEngine;
using System.Collections;

public class LanderFollow : MonoBehaviour
{
	private Transform player;

	// Use this for initialization
	void Awake () {
		var playerObj = GameObject.FindGameObjectWithTag("Player") as GameObject;
		player = playerObj.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(player != null)
		{
			var pos = transform.position;
			pos.x = player.position.x;
			transform.position = pos;
		}
	}
}
