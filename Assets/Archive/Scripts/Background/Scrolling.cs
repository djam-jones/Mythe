﻿using UnityEngine;
using System.Collections;

// Boy

public class Scrolling : MonoBehaviour {

    [SerializeField] 
    private float speed = 0f;
    private float position = 0f;

    private void Update() {
        position += speed * Time.deltaTime;

        if (position > 1.0f) {
            position = 0f;
        }

        renderer.material.mainTextureOffset = new Vector2(position, 0);
    }

}