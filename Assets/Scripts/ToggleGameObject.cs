using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    public GameObject gameObject;

    public void ToggleObject()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    
}
