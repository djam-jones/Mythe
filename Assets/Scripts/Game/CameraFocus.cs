using UnityEngine;
using System.Collections;

    // Boy Voesten

public class CameraFocus : MonoBehaviour 
{

    private GameObject _target;
    private float speed = 1f;

    public GameObject target 
    {
        get 
        {
            return _target;
        }
        set 
        {
            _target = value;
        }
    }

	void Update()
    {
        float currentSpeed = speed * (_target.transform.position - transform.position).magnitude;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_target.transform.position.x, _target.transform.position.y, -10), currentSpeed * Time.deltaTime);
	}

}
