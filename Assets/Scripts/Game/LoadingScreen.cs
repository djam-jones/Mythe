using UnityEngine;
using System.Collections;

//Djamali

public class LoadingScreen : MonoBehaviour 
{
	//Create a Boolean '_loading' and set it on true so it will show the loading screen on start up.
	private bool _loading = true;
	//Set stuff for the Textures
	private int _textureRandomizer;
	public Texture[] allLoadingTextures;
	private Texture _randomTexture;

	void Awake()
	{
		//Won't the Destroy the Gameobject this is script is attached to on loading another scene
		DontDestroyOnLoad(gameObject);

		_textureRandomizer = Random.Range(0, allLoadingTextures.Length);
		_randomTexture = allLoadingTextures[_textureRandomizer];
	}

	void Update()
	{
		if(Application.isLoadingLevel)
		{
			_loading = true;
		}
		else if(!Application.isLoadingLevel)
		{
			_loading = false;
		}
	}

	void OnGUI()
	{
		if(_loading)
		{
			print("Loading Level...");
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _randomTexture, ScaleMode.StretchToFill);
		}
	}

}
