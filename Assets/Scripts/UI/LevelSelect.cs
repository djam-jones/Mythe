//written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour 
{
	[SerializeField]private GameObject[] _allButtons;
	[SerializeField]private GameObject _page1;
	[SerializeField]private GameObject _page2;
	[SerializeField]private GameObject _lArrow;
	[SerializeField]private GameObject _rArrow;
	private int _currentPage = 1;
	private PlayerData _playerData;
	
	void Awake ()
	{
		_playerData = GameObject.FindGameObjectWithTag(AllTagsConstants.playerData).GetComponent<PlayerData>();
		UpdatePage();
	}

	private void UpdatePage()
	{
		for(int i = 0; i < _playerData.unlockedLevels; i++)
		{
			_allButtons[i].SetActive(true);
			Debug.Log("unlocking!");
		}
		if(_currentPage == 1)
		{
			_page1.SetActive(true);
			_page2.SetActive(false);
			_lArrow.SetActive(false);
			_rArrow.SetActive(true);
		}
		else if(_currentPage == 2)
		{
			_page1.SetActive(false);
			_page2.SetActive(true);
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
