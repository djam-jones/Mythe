using UnityEngine;
using System.IO;
using System.Collections;

public class CaptureScreenshotScript : MonoBehaviour {

	string _imageURL = "http://localhost/folder/screenshot.php";

	void Start()
	{
		//
	}

	void Update()
	{
		//Take a Screenshot of the game
		if(Input.GetKeyDown(KeyCode.F1))
		{
			StartCoroutine(UploadPNG());
		}
	}

	IEnumerator UploadPNG()
	{
		//Read the Screen after rendering is completed.
		yield return new WaitForEndOfFrame();

		//Create a texture the of the screen in the RGB24 Format.
		int width = Screen.width;
		int height = Screen.height;
		Texture2D img = new Texture2D(width, height, TextureFormat.RGB24, false);

		//Read screen contents into the Texture.
		img.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		img.Apply();

		//Encode texture into PNG file
		byte[] bytes = img.EncodeToPNG();
		Destroy(img);

		//Create Web Form
		WWWForm form = new WWWForm();

		form.AddField("frameCount", Time.frameCount.ToString());
		form.AddBinaryData("fileToUpload", bytes, "screenshot.png", "image/png");

		//Upload to a cgi script
		WWW www = new WWW(_imageURL, form);
		yield return www;
		if(!string.IsNullOrEmpty(www.error))
		{
			print(www.error);
		}
		else
		{
			print("Finished Uploading Screenshot!");
			//Update Screenshot Notification Text
		}
	}

}