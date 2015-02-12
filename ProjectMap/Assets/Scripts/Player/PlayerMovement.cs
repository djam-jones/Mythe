using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour 
{

    public float speed = 10f;

    void Update() 
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
    }
    

}
