using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyperlink : MonoBehaviour
{
    [SerializeField] private string URL;

    public void Open()
    {
        Application.OpenURL(URL);
    }
}
