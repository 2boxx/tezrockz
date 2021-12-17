using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RarityMeter : MonoBehaviour
{
    public TextMeshProUGUI commonText;
    public TextMeshProUGUI epicText;
    public TextMeshProUGUI legendaryText;
    
    public int commonPercentage;
    public int epicPercentage;
    public int legendaryPercentage;

    private void Update()
    {
        UpdatePercentageTexts();
    }

    public void UpdatePercentageTexts()
    {
        commonText.text = commonPercentage+"%";
        epicText.text = epicPercentage+"%";
        legendaryText.text = legendaryPercentage+"%";
    }
}
