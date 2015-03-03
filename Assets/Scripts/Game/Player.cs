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

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.transform.tag == "MovingPlatform")
		{
			transform.SetParent(other.transform);
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if(other.transform.tag == "MovingPlatform")
		{
			transform.SetParent(null);
		}
	}
}
