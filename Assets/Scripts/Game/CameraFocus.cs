using UnityEngine;
using System.Collections;

    // Boy Voesten

public class CameraFocus : MonoBehaviour 
{
    private static GameObject _target;

    public static GameObject target {
        get {
            //Debug.Log("Get - Camera target = " + _target);
            return _target;
        }
        set {
            //Debug.Log("Set - Camera Target to: " + value);
            _target = value;
        }
    }

	void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(_target.transform.position.x, _target.transform.position.y, -10), 5f * Time.deltaTime);
	}

}
