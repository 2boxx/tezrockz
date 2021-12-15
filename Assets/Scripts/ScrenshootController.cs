using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrenshootController : MonoBehaviour
{
    private bool _takeScrenshootOnNextFrame;
    private Camera _cam;
    private Texture2D _screnshoot;
    public int width;
    public int height;
    public Image screenshootPreview;
    private void Awake()
    {
        _cam = FindObjectOfType<Camera>();
    }

    private void OnPostRender()
    {
        if (_takeScrenshootOnNextFrame)
        {
            _takeScrenshootOnNextFrame = false;
        

            _screnshoot = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, Screen.width, Screen.height);
            _screnshoot.ReadPixels(rect,0,0);

           byte[] byteArray = _screnshoot.EncodeToPNG();
           System.IO.File.WriteAllBytes(Application.dataPath+"/CameraScrenshoot.png",byteArray);

        }
    }

    public void TakeScrenshoot()
    {
        _takeScrenshootOnNextFrame = true;

        //_screnshoot = ScreenCapture.CaptureScreenshotAsTexture(1);
     //screenshootPreview.sprite = ConvertToSprite(_screnshoot);

    }

    private Sprite ConvertToSprite( Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }
    
   
 
}



