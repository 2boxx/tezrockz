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
    public float nextReward = 20;
    public Image rewardIndicator;
    private float rewardInterval = 20;

    public UnityEvent onReward;

    private void Update()
    {
        if (!_rocksManager.GetHighestRock()) return;
        
        float distance = Vector2.Distance(startPoint.transform.position, _rocksManager.GetHighestRock().transform.position);

        heightText.text = distance.ToString("0") + "m";

        rewardIndicator.fillAmount = nextReward / 1;
        if (distance>= nextReward)
        {
            nextReward += rewardInterval;
            onReward.Invoke();
        }
    }
}
