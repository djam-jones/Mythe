using UnityEngine;
using System.Collections;

public class ToBeSavedData : MonoBehaviour {

	private int gold;
	private DataUI dataUI;
	
	void Awake () 
	{
		dataUI = gameObject.GetComponent<DataUI>();	
	}
	void Start () 
	{
		dataUI.UpdateUI (gold);
	}

	public int GetGold()
	{
		return gold;
	}

	public void SetGold(int amount)
	{
		gold = amount;
		dataUI.UpdateUI (gold);
	}
	public void updateGold(int amount)
	{
		gold += amount;
		dataUI.UpdateUI (gold);
	}
}
