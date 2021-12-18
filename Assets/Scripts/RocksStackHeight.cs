using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RocksStackHeight : MonoBehaviour
{
    [SerializeField] private RocksManager _rocksManager;

    
    public TextMeshProUGUI heightText;

    public Transform startPoint;

    public int lineAmount;
    public GameObject heightLine;

    
    [Header("Height Reward")]
    public float rewardInterval = 10;
    private float nextReward = 10;

    private void Start()
    {
        SpawnHeightLines();
    }

    private void Update()
    {
        if (!_rocksManager.GetHighestRock()) return;
        
        float distance = Mathf.Round(Vector2.Distance(startPoint.transform.position, _rocksManager.GetHighestRock().transform.position));

        heightText.text = distance + "m";


        // if (distance>= nextReward)
        // {
        //     nextReward += rewardInterval;
        //     onReward.Invoke();
        //
        // }
    }


    public void SpawnHeightLines()
    {
        int acumulator = 0;


        for (int i = 0; i < lineAmount; i++)
        {
            acumulator++;
            Vector2 linePos = new Vector2(0, (rewardInterval+startPoint.position.y) * acumulator);
            var line = Instantiate(heightLine, linePos, quaternion.identity);
            line.transform.SetParent(startPoint);
        }
        
        
    }
}
