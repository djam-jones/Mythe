//written by Rob Verhoef
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelect : MonoBehaviour 
{
	[SerializeField]private GameObject[] _allButtons;
	[SerializeField]private GameObject _page1;
	[SerializeField]private GameObject _page2;
	[SerializeField]private GameObject _lArrow;
	[SerializeField]private GameObject _rArrow;
	[SerializeField]private GameObject _menuArrow;
    [SerializeField]private Text[] _scoreTxt;
	private int _currentPage = 1;
	private PlayerData _playerData;
	
	void Awake()
	{
		_playerData = GameObject.FindGameObjectWithTag(AllTagsConstants.playerData).GetComponent<PlayerData>();
		UpdatePage();
	}

    void OnLevelWasLoaded(int lvl) 
    {
        UpdatePage();
    }

	private void UpdatePage()
	{
		for(int i = 0; i <= _playerData.unlockedLevels; i++)
		{
			_allButtons[i].SetActive(true);
            _scoreTxt[i].text = "Highscore: " + _playerData.GetHighscore(i);
		}

		if(_currentPage == 1)
		{
			_page1.SetActive(true);
			_page2.SetActive(false);
            _menuArrow.SetActive(true);
			_lArrow.SetActive(false);
			_rArrow.SetActive(true);
		}
		else if(_currentPage == 2)
		{
			_page1.SetActive(false);
			_page2.SetActive(true);
            _menuArrow.SetActive(false);
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

    public void SetLvl(int lvl) 
    {
        _playerData.currentLvl = lvl;
    }

}
