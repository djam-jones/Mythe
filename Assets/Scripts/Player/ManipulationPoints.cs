//written by Rob Verhoef
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManipulationPoints : MonoBehaviour 
{
	[SerializeField]
	private Scrollbar _pointBar;
	[SerializeField]
	private float decrease;
	[SerializeField]
	private float increase;

	public float points;
	public bool dragging;
	public bool recharging;

	void Update () 
	{
		if(dragging == true)
		{
			points -= Time.deltaTime * decrease;
			_pointBar.size = points/100;
		}
		else if(recharging == true && points < 100)
		{
			points += Time.deltaTime * increase;
			_pointBar.size = points/100f;
		}
	}
}
