using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	void Update()
	{
		float x = Input.GetAxis("Horizontal") * 5 * Time.deltaTime;
		float y = Input.GetAxis("Vertical") * 10 * Time.deltaTime;

		transform.Translate(new Vector2(x, y));
	}
}
