//written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class ManipulationPoints : MonoBehaviour 
{
	public float points;
	public float decrease;
	public float increase;
	public bool dragging;

	void Update () 
	{
		if(dragging == true)
		{
			points -= Time.deltaTime * decrease;
		}
		else if(dragging == false && points < 100)
		{
			points += Time.deltaTime * increase;
		}
	}
}
