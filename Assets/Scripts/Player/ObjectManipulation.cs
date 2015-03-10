//written Rob Verhoef
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectManipulation : MonoBehaviour 
{
	private Vector3 _mousePos;
	[SerializeField]
	private Camera _camera;
	[SerializeField]
	private Scrollbar _pointBar;
	[SerializeField]
	private float _decrease;
	[SerializeField]
	private float _increase;
	[SerializeField]
	private float _points;
	private bool _recharge;

	void Update () 
	{

		_mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);	
		_mousePos.z = 0;
		RaycastHit hit;
		if(Input.GetMouseButton (0) && _points > 0)
		{
			if(Physics.Raycast(transform.position, _mousePos - transform.position, out hit, 1000f))
			{
				if(hit.collider.tag == "Object" && _mousePos.x - hit.collider.transform.position.x <= 1 && _mousePos.y - hit.collider.transform.position.y <= 1)
				{
					hit.collider.transform.position = _mousePos;
					_recharge = false;
					_points -= Time.deltaTime * _decrease;
					_pointBar.size = _points/100;
					Debug.Log("hit!");
				}
			}
		}

		else if(Input.GetMouseButtonUp (0))
		{
			_recharge = true;
		}
		if(_recharge == true && _points < 100)
		{
			_points += Time.deltaTime * _increase;
			_pointBar.size = _points/100f;
		}
	}
}