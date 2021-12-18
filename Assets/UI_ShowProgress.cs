using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ShowProgress : MonoBehaviour
{
    public RockCardSelector cardSelector;
    
    private float ownedRockz;
    private float usedRockz;
    public float progress; //User progress in game: 0 to 1.
    
    public Transform startPos;
    public Transform endPos;

    public Transform tracker;

    public void AddUsedRock()
    {
        usedRockz++;
    }
    
    private void Start()
    {
        ownedRockz = CountActiveRockz();
        usedRockz = 0f;
    }

    private float CountActiveRockz()
    {
        float count = 0f;
        foreach (var card in cardSelector.activeCards)
        {
            foreach (var shape in card.unitsPerShape)
            {
                count += shape;
            }
        }

        return count;
    }
    
    private void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        if (ownedRockz == 0) return;
        progress = usedRockz / ownedRockz;
        tracker.position = Vector3.Lerp(startPos.transform.position, endPos.transform.position, progress);
    }
}
