using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RocksStackHeight : MonoBehaviour
{
    [SerializeField] private RocksManager _rocksManager;

    
    public TextMeshProUGUI heightText;

    public Transform startPoint;

    
    [Header("Height Reward")]
    public float nextReward = 10;
    private float rewardInterval = 10;

    public UnityEvent onReward;

    private void Update()
    {
        if (!_rocksManager.GetHighestRock()) return;
        
        float distance = Mathf.Round(Vector2.Distance(startPoint.transform.position, _rocksManager.GetHighestRock().transform.position));

        heightText.text = distance + "m";


        if (distance>= nextReward)
        {
            nextReward += rewardInterval;
            onReward.Invoke();
        }
    }

 
}
