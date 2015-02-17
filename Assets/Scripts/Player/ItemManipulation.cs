//written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class ItemManipulation : MonoBehaviour 
{
	private float _objectX;
	private float _objectY;
	[SerializeField]
	private ManipulationPoints _manipulationPoints;

	void Update () 
	{
		_objectX = Input.mousePosition.x;
		_objectY = Input.mousePosition.y;

		if(Input.GetMouseButtonUp(0))
		{
			_manipulationPoints.dragging = false;
			Invoke("EnableManipulation", 5f);
		}
	}

	void OnMouseDrag()
	{
		if(_manipulationPoints.points > 0)
		{
			transform.position = Camera.main.ScreenToWorldPoint(new Vector3(_objectX, _objectY, 10f));
			_manipulationPoints.dragging = true;
			_manipulationPoints.recharging = false;
		}
	}

	private void EnableManipulation()
	{
		_manipulationPoints.recharging = true;
	}
}
