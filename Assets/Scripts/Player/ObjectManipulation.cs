//written Rob Verhoef
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectManipulation : MonoBehaviour 
{
	private Vector3 _mousePos;
	[SerializeField]private Camera _camera;
	[SerializeField]private Scrollbar _pointBar;
	[SerializeField]private float _decrease;
	[SerializeField]private float _increase;
	[SerializeField]private float _points;
	private bool _recharge;
	private Transform _dragObject;
    private Vector3 _dragOffset;
    private Vector3 _clickOffset;
    private Vector3 _mouseClickPos;
    private Vector2 _offset;

	void Update () 
	{
        if (!isActiveAndEnabled) return;

		_mousePos = _camera.ScreenToWorldPoint (Input.mousePosition);	
		_mousePos.z = 0;

		if (Input.GetMouseButtonDown (0) && _points > 0) 
		{
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			{
				if (hit.collider != null && hit.collider.tag == AllTagsConstants.objectTag && _mousePos.x - hit.collider.transform.position.x <= 1.5 && _mousePos.y - hit.collider.transform.position.y <= 1.5) 
				{
					_dragObject = hit.collider.transform;
                    _recharge = false;

                    _dragOffset = _dragObject.position - _mousePos;
                    _offset = _mousePos - _dragObject.position;
                    Debug.Log("dragOffset: " + _dragOffset);
                    _mouseClickPos = _mousePos;
					
				}
			}
		} 
		else if (Input.GetMouseButtonUp (0)) 
		{
			_recharge = true;
			_dragObject = null;
		}
		else if (_points <= 0)
		{
			_dragObject = null;
		}

        // Drag
		if (!_recharge && _dragObject != null) 
		{

            Rigidbody2D dragObjRB = _dragObject.GetComponent<Rigidbody2D>();
            if (Vector2.Distance(_mousePos,_dragObject.position) < .5) {
                Debug.Log("Smaller than 1");
                dragObjRB.velocity = Vector2.zero;
                _offset = new Vector2(.75f, .75f);
            } else {
                _offset = _mousePos - _dragObject.position;
            }

            dragObjRB.velocity += _offset;            
            
            //_clickOffset = _mousePos - _mouseClickPos;
            //Debug.Log(_clickOffset);
            //offset = _clickOffset - _dragObject.position;
            //dragObjRB.MovePosition(dragObjRB.position + (Vector2)_clickOffset * Time.deltaTime);
            //dragObjRB.AddForce(offset);// _dragOffset);
            //_dragObject.transform.position = Vector3.Lerp(_dragObject.transform.position, _mousePos, Time.smoothDeltaTime * 10);
            
			//_points -= Time.deltaTime * _decrease;
			_pointBar.size = _points / 100;
		}
		else if(_recharge && _points < 100)
		{
			_points += Time.deltaTime * _increase;
			_pointBar.size = _points / 100;
		}

	}

	private void Drag ()
	{

		/*if (!_recharge && _dragObject != null) 
		{
			_dragObject.position = _mousePos;
			_points -= Time.deltaTime * _decrease;
			_pointBar.size = _points / 100;
		}
		else if(_recharge && _points < 100)
		{
			_points += Time.deltaTime * _increase;
			_pointBar.size = _points / 100;
		}*/
	}
}
