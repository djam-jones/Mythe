//written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class ItemManipulationScript : MonoBehaviour {

	private float _objectX;
	private float _objectY;
	private float _telePoints;

	void Update () 
	{
		_objectX = Input.mousePosition.x;
		_objectY = Input.mousePosition.y;
	}

	void OnMouseDrag()
	{
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(_objectX, _objectY, 10f));
	}
}
