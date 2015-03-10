using UnityEngine;
using System.Collections;

public class ChangeLevelFade : MonoBehaviour 
{
	public Texture fadeOutTexture;
	public float fadeSpeed = 0.8f;
	
	private int drawDepth = -1000;
	private float alpha = 1f;
	private int fadeDir = -1;

	private bool _humanIn;
	private bool _alienIn;

	private string _humanTag = "Human";
	private string _alienTag = "Alien";

    private PlayerData playerData;
    private const string HIGHSCORE = "HighScore";

    void Start() 
    {
        playerData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.tag == _humanTag)
		{
			Debug.Log ("Human Is In!");
			_humanIn = true;
		}
		if(other.transform.tag == _alienTag)
		{
			Debug.Log ("Alien Is In!");
			_alienIn = true;
		}

		if(_humanIn && _alienIn)
		{
			Debug.Log("Change Level!");
			StartCoroutine(ChangeLevel(Application.loadedLevel + 1));
		}
	}

	IEnumerator ChangeLevel(int lvlIndex)
	{
        float fadeTime = BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
        
        if (playerData.score > playerData.highscore)
        {
            
            playerData.highscore = playerData.score;
            Debug.Log("Highscore! " + playerData.highscore);
            Application.LoadLevel(HIGHSCORE);
        } 
        else 
        {
            Debug.Log("No highscore...");
            Application.LoadLevel("PrototypeLvl01");
        }
		
		
	}

	void OnGUI()
	{
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);
		
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
	}
	
	public float BeginFade(int direction)
	{
        Debug.Log("BeginFade");
		fadeDir = direction;
		return fadeSpeed;
	}
	
	void OnLevelWasLoaded()
	{
		BeginFade(-1);
        Debug.Log("OnLevelWasLoaded");
	}

}
