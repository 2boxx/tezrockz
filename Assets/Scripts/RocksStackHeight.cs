using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RocksStackHeight : MonoBehaviour
{
    [SerializeField] private RocksManager _rocksManager;

    
    public TextMeshProUGUI heightText;

    public Transform startPoint;


    private void Update()
    {
        if(_rocksManager.GetHighestRock())
        heightText.text = Vector2.Distance(startPoint.transform.position, _rocksManager.GetHighestRock().transform.position).ToString("0")+"m";
    }
}
