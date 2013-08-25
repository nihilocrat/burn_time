using UnityEngine;
using System.Collections;

public class LanderGameDirector : MonoBehaviour
{
	public bool gameOver = false;
	public int score = 0;
	public LanderControls player;
	
	public Transform gameOverScreen;
	public Transform surviveScreen;
	
	static private LanderGameDirector singleton;
	
	static public LanderGameDirector Instance
	{
		get
		{
			return singleton;
		}
	}
	void Awake()
	{
		singleton = this;
	}
	
	void OnGameOver(bool survived)
	{
		gameOver = true;
		var score = player.score;
		var remaining = GameObject.FindGameObjectsWithTag("Rescuable").Length;
		
		Transform endScreen;
		if(!survived)
		{
			endScreen = gameOverScreen;
		}
		else
		{
			endScreen = surviveScreen;
		}
		
		endScreen.gameObject.SetActive(true);
		
		var remainingMeter = endScreen.GetComponentInChildren<BlockMeter>();
		remainingMeter.SetBlocks(remaining);
	}
	
	void Update()
	{
		if(gameOver && Input.GetButtonDown("Spacebar"))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		else if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
		
		if(player.fuel <= 0f && Mathf.Approximately(player.rigidbody.velocity.magnitude, 0f))
		{
			OnGameOver(false);
		}
	}
}
