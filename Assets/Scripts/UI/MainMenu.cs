using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public void Play ()
	{
		Application.LoadLevel ("LevelSelect");
	}

	public void Credits ()
	{
		Application.LoadLevel ("Credits");
	}

	public void Quit ()
	{
		Application.Quit ();
	}
}
