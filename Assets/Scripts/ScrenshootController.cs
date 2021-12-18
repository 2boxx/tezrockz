using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class ScrenshootController : MonoBehaviour
{
    


    private Camera _cam;
    [SerializeField]private Texture2D _screnshoot;

    public Image screenshootPreview;

    public GameObject twitter;
    
    private bool _takeScrenshoot;

    public GameObject UI_Screnshoot;
    
    private void Awake()
    {
        _cam = FindObjectOfType<Camera>();
    }

    public void TakeScrenshoot()
    {

        //take screnshoot
        //_screnshoot = ScreenCapture.CaptureScreenshotAsTexture(1);
        StartCoroutine(TakeScrenshootCoroutine());


    }

    
    IEnumerator TakeScrenshootCoroutine()
    {

       twitter.SetActive(true);
        yield return new WaitForEndOfFrame();
        Debug.Log("TAKE SCRENSHOOT");
       //Texture2D newScrenshoot = ScreenCapture.CaptureScreenshotAsTexture(ScreenCapture.StereoScreenCaptureMode.BothEyes);
       
       // create a texture to pass to encoding
       Texture2D newScrenshoot  = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

       //put buffer into texture
       newScrenshoot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
       newScrenshoot.Apply();

       //split the process up--ReadPixels() and the GetPixels() call inside of the encoder are both pretty heavy
       yield return 0;
       
        _screnshoot = new Texture2D(newScrenshoot.width, newScrenshoot.height);
      
        _screnshoot.SetPixels(newScrenshoot.GetPixels());
        _screnshoot.Apply();  
         
        //update preview sprite
        screenshootPreview.sprite = ConvertToSprite(_screnshoot);
        screenshootPreview.preserveAspect = true;
        Destroy(newScrenshoot);
        twitter.SetActive(false);

    }



    [DllImport("__Internal")]
    public static extern void DownloadFile(byte[] array, int byteLength, string fileName);

    public void SaveScrenshoot()
    {
        string dateFormat = "yyyy-MM-dd-HH-mm-ss";
        string filename = System.DateTime.Now.ToString(dateFormat);
        Texture2D donwloadScrenshoot = _screnshoot;
        byte[] texture = donwloadScrenshoot.EncodeToPNG();
        
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            Debug.Log("Save screnshoot WEBGL");
            DownloadFile(texture, texture.Length, filename + ".png");

        }    
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            Debug.Log("Save screnshoot PC");
            //string path = EditorUtility.SaveFilePanel
            byte[] byteArray = _screnshoot.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath+"/CameraScrenshoot.png",byteArray);
        }

        Destroy(donwloadScrenshoot);
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

    public void SetActiveUIScrenshoot()
    {
        StartCoroutine(SetActiveUIScrenshootDelay());
    }
     IEnumerator SetActiveUIScrenshootDelay()
     {
         yield return new WaitForSeconds(0.1f);
         UI_Screnshoot.SetActive(true);
     }


    
    
    
}



