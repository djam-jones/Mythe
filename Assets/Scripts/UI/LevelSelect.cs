//written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour 
{
	[SerializeField]
	private GameObject _Button1;
	[SerializeField]
	private GameObject _Button2;
	[SerializeField]
	private GameObject _Button3;
	[SerializeField]
	private GameObject _Button4;
	[SerializeField]
	private GameObject _lArrow;
	[SerializeField]
	private GameObject _rArrow;
	private int _currentPage = 1;

	void Awake ()
	{
		//GameObject.FindGameObjectWithTag().GetComponent<PlayerData>();
	}

	private void UpdatePage()
	{
		if(_currentPage == 1)
		{
			_Button1.SetActive(true);
			_Button2.SetActive(true);
			_Button3.SetActive(false);
			_Button4.SetActive(false);
			_lArrow.SetActive(false);
			_rArrow.SetActive(true);
		}
		else if(_currentPage == 2)
		{
			_Button1.SetActive(false);
			_Button2.SetActive(false);
			_Button3.SetActive(true);
			_Button4.SetActive(true);
			_lArrow.SetActive(true);
			_rArrow.SetActive(false);
		}
	}

	public void RightButton ()
	{
			_currentPage += 1;
			UpdatePage();
	}

	public void LeftButton ()
	{
			_currentPage -= 1;
			UpdatePage();
	}

	public void LoadLevel1 ()
	{
		Application.LoadLevel ("Level01");
	}

	public void LoadLevel2 ()
	{
		Application.LoadLevel ("Level02");
	}

	public void LoadLevel3 ()
	{
		Application.LoadLevel ("Level03");
	}

	public void LoadLevel4 ()
	{
		Application.LoadLevel ("Level04");
	}
}
