using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D cursorClicked;
    public Texture2D cursorDefault;


    private void Awake()
    {
           ChangeCursor(cursorDefault);
           Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) ChangeCursor(cursorClicked);
        if (Input.GetMouseButtonUp(0)) ChangeCursor(cursorDefault);
        if (Input.GetMouseButtonDown(1)) ChangeCursor(cursorClicked);
        if (Input.GetMouseButtonUp(1)) ChangeCursor(cursorDefault);
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        Vector2 hotspot = new Vector2(cursorType.width/2f  , cursorType.height/2f);
        Cursor.SetCursor(cursorType,hotspot, CursorMode.ForceSoftware);
    }

 
}
