using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class ScrenshootController : MonoBehaviour
{
    


    private Camera _cam;
    private Texture2D _screnshoot;

    public Image screenshootPreview;
    private void Awake()
    {
        _cam = FindObjectOfType<Camera>();
    }



    public void TakeScrenshoot()
    {
        _screnshoot = ScreenCapture.CaptureScreenshotAsTexture(1);
        screenshootPreview.sprite = ConvertToSprite(_screnshoot);
        screenshootPreview.preserveAspect = true;
    }
    
    
    [DllImport("__Internal")]
    public static extern void DownloadFile(byte[] array, int byteLength, string fileName);

    public void SaveScrenshoot()
    {
        //EditorUtility.SaveFilePanel
        Debug.Log("SaveScrenshoot");
       /*
        Texture2D texture = _screnshoot;
        byte[] textureBytes = texture.EncodeToJPG();
        DownloadFile(textureBytes, textureBytes.Length, "image.jpg");
        Destroy(texture);*/
       StartCoroutine(RecordUpscaledFrame(1));
    }
    IEnumerator RecordUpscaledFrame(int screenshotUpscale)
    {
        yield return new WaitForEndOfFrame();
        int resWidthN = Camera.main.pixelWidth * screenshotUpscale;
        int resHeightN = Camera.main.pixelHeight * screenshotUpscale;
        string dateFormat = "yyyy-MM-dd-HH-mm-ss";
        string filename = resWidthN.ToString() + "x" + resHeightN.ToString() + "px_" + System.DateTime.Now.ToString(dateFormat);
        Texture2D screenShot = ScreenCapture.CaptureScreenshotAsTexture(screenshotUpscale);
        byte[] texture = screenShot.EncodeToPNG();
        DownloadFile(texture, texture.Length, filename + ".png");
        Destroy(screenShot);
    }
    
    
    
    public void DiscardScrenshoot()
    {
        _screnshoot = null;
        screenshootPreview.sprite = null;
    }

    private Sprite ConvertToSprite( Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }
    
   
 
}



