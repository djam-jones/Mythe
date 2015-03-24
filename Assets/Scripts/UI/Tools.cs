﻿using UnityEngine;
using System.Collections;

public class Tools : MonoBehaviour {

	public void LoadScene(string scene)
    {
        Application.LoadLevel(scene);
    }

    public void ToggleActive(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }
}
