using UnityEngine;
using System.Collections;

public class CameraFocus : MonoBehaviour 
{

    private static GameObject _target;

	void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_target.transform.position.x, _target.transform.position.y, -10), 3f * Time.deltaTime);
	}

    public static void SetFocusOn(GameObject target)
    {
        _target = target;
    }

    public static GameObject GetTarget() 
    {
        return _target;
    }

}
