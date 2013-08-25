using UnityEngine;
using System.Collections;

public class TitleDirector : MonoBehaviour
{
	void Update ()
	{
		if(Input.GetButtonDown("Spacebar"))
		{
			Application.LoadLevel(Application.loadedLevel+1);
		}
		else if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
