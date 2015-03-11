using UnityEngine;
using System.Collections;
using System.IO;

public class Screenshot : MonoBehaviour 
{

    // Grab a screen shot and upload it to a CGI script.
    // The CGI script must be able to hande form uploads.
    string _uploadURL = "http://localhost/bap/uploadfile.php";

    public void TakeScreenshot() 
    {
        StartCoroutine(UploadPNG());
    }

    IEnumerator UploadPNG() 
    {
        // We should only read the screen after all rendering is complete
        yield return new WaitForEndOfFrame();

        // Create a texture the size of the screen, RGB24 format
        int width = Screen.width;
        int height = Screen.height;
        Texture2D tex2D = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
        tex2D.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex2D.Apply();

        // Encode texture into PNG
        byte[] bytes = tex2D.EncodeToPNG();
        Destroy(tex2D);

        // Create a Web Form
        WWWForm form = new WWWForm();
        form.AddField("frameCount", Time.frameCount.ToString());
        form.AddBinaryData("fileToUpload", bytes);

        // Upload to a cgi script
        WWW www = new WWW(_uploadURL, form);
        yield return www;

        // Error reporting
        if (www.error != null) 
        {
            print(www.error);
        }
        else 
        {
            print("Finished Uploading Screenshot");
        }

    }


}
