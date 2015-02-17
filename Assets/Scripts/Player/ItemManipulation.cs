//written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class ItemManipulation : MonoBehaviour 
{

	private float _objectX;
	private float _objectY;
	[SerializeField]
	private float _telePoints;
	[SerializeField]
	private float _decreaseTime;
	private bool _dragging;

	void Update () 
	{
		_objectX = Input.mousePosition.x;
		_objectY = Input.mousePosition.y;
	}

	void OnMouseDrag()
	{
		if(_telePoints > 0)
		{
			transform.position = Camera.main.ScreenToWorldPoint(new Vector3(_objectX, _objectY, 10f));
			_telePoints -= Time.deltaTime * _decreaseTime;
		}
	}
}
