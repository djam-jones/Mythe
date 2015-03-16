//written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour 
{
	public void LoadLevel1 ()
	{
		Application.LoadLevel ("Level01");
	}

	public void LoadLevel2 ()
	{
		Application.LoadLevel ("Level02");
	}

	public void LoadLevel3 ()
	{
		Application.LoadLevel ("Level03");
	}

	public void LoadLevel4 ()
	{
		Application.LoadLevel ("Level04");
	}

	public void LoadLevel5 ()
	{
		Application.LoadLevel ("Level05");
	}
}
