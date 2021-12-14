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
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height/2f *-0.2f);
        Cursor.SetCursor(cursorType,hotspot, CursorMode.Auto);
    }

 
}
