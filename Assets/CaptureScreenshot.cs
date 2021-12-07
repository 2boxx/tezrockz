using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


//Clase para sacar fotos o grabar videos
public class ScreenshotManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) TakeScreenshot("fotito");
    }

    public void TakeScreenshot(string fileName)
    {
        //sacar foto de toda la pila de piedras?Grabar gif?
    }
}

