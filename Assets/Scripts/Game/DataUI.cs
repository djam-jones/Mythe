﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

    // Rob Verhoef

public class DataUI : MonoBehaviour {

	public Text goldText;
	
	public void UpdateUI(int gold) 
	{
		goldText.text = "Gold: " + gold; 
	}
}
