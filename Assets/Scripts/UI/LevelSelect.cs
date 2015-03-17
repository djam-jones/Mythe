//written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour 
{
	[SerializeField]
	private GameObject _levelButton1;
	[SerializeField]
	private GameObject _levelButton2;
	[SerializeField]
	private GameObject _levelButton3;
	[SerializeField]
	private GameObject _levelButton4;
	[SerializeField]
	private GameObject _levelButton5;
	[SerializeField]
	private GameObject _lArrow;
	[SerializeField]
	private GameObject _rArrow;
	private int _currentPage = 1;

	private void UpdatePage()
	{
		if(_currentPage == 1)
		{
			_levelButton1.SetActive(true);
			_levelButton2.SetActive(true);
			_levelButton3.SetActive(false);
			_levelButton4.SetActive(false);
			_levelButton5.SetActive(false);
			_lArrow.SetActive(false);
		}
		else if(_currentPage == 2)
		{
			_levelButton1.SetActive(false);
			_levelButton2.SetActive(false);
			_levelButton3.SetActive(true);
			_levelButton4.SetActive(true);
			_levelButton5.SetActive(false);
			_lArrow.SetActive(true);
			_rArrow.SetActive(true);
		}
		else if(_currentPage == 3)
		{
			_levelButton1.SetActive(false);
			_levelButton2.SetActive(false);
			_levelButton3.SetActive(false);
			_levelButton4.SetActive(false);
			_levelButton5.SetActive(true);
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

	public void LoadLevel5 ()
	{
		Application.LoadLevel ("Level05");
	}
}
