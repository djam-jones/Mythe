using UnityEngine;
using System.Collections;

public class LevelCheck : MonoBehaviour 
{

	private const string _LEVELSELECT = "LevelSelect";
    
    public Texture fadeOutTexture;
	public float fadeSpeed = 0.8f;

	private int _drawDepth = -1000;
	private float _alpha = 1f;
	private int _fadeDir = -1;
	private bool _humanIn;
	private bool _alienIn;
    private PlayerData _playerData;
    

    void Start() 
    {
        _playerData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.tag == AllTagsConstants.humanTag)
		{
			_humanIn = true;
		}
		if(other.transform.tag == AllTagsConstants.alienTag)
		{
			_alienIn = true;
		}

		if(_humanIn && _alienIn)
		{
			Debug.Log("Change Level!");
            _playerData.CheckScore();
			StartCoroutine(ChangeLevel());
		}
	}

	IEnumerator ChangeLevel()
	{
        float fadeTime = BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
        
        Application.LoadLevelAsync(_LEVELSELECT);
	}

	void OnGUI()
	{
		_alpha += _fadeDir * fadeSpeed * Time.deltaTime;
		_alpha = Mathf.Clamp01(_alpha);
		
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, _alpha);
		GUI.depth = _drawDepth;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
	}
	
	public float BeginFade(int direction)
	{
        Debug.Log("BeginFade");
		_fadeDir = direction;
		return fadeSpeed;
	}
	
	void OnLevelWasLoaded()
	{
		BeginFade(-1);
        Debug.Log("OnLevelWasLoaded");
	}

}
