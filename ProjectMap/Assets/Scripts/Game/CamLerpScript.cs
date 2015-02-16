//written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class CamLerpScript : MonoBehaviour {

	private Transform _startingPos;
	private Transform _targetPos;
	[SerializeField]
	private Transform _target1;
	[SerializeField]
	private Transform _target2;
	private bool _switched;
	[SerializeField]
	private bool _becomeChild;
	[SerializeField]
	private float _transitionTime;
	private float _t;
	[SerializeField]
	private GameObject button;

	public void SwitchCam ()
	{
		StartCoroutine (ChangeTarget ());
	}
	IEnumerator ChangeTarget () 
	{
		Vector3 _startingPos = transform.position;
		//makes sure the camera switches between targets correctly, also add the camera as a child  cof the target
		if(_switched == true)
		{
			_targetPos = _target1;
			if(_becomeChild == true)
			{
				this.transform.parent = _target1.transform;
			}
			_switched = false;
		}
		else if(_switched == false)
		{
			_targetPos = _target2;
			if(_becomeChild == true)
			{
				this.transform.parent = _target2.transform;
			}
			_switched = true;
		}
		//the camera moves to the target within the time given in _transitionTime
		while (_t < _transitionTime)
		{
			button.SetActive(false);
			_t += Time.deltaTime * (Time.timeScale/_transitionTime);
			transform.position = Vector3.Lerp(_startingPos, _targetPos.position, _t);
			this.transform.Translate(0,0,-10);
			yield return 0;
		}
		_t = 0;
		button.SetActive(true);
	}

	void Update ()
	{
		//if the camera doesnt becoma child, it follows the active target instead
		if(_becomeChild == false)
		{
			this.transform.position = _targetPos.position;
			this.transform.Translate(0,0,-10);
		}
	}
}
