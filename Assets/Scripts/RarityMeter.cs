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

    public int totalRocks;

    public void UpdatePercentageTexts()
    {
        if (totalRocks == 0 ) return;
        if (commonPercentage > 0) commonText.text = commonPercentage/totalRocks*100+"%";
        if (epicPercentage > 0) epicText.text = epicPercentage/totalRocks*100+"%";
        if (legendaryPercentage > 0) legendaryText.text = (legendaryPercentage/totalRocks)*100+"%";
    }


    public void AddPercentage(RockCardMonobehaviour rock)
    {
        switch (rock.rarity)
        {
            case rarities.common:
                commonPercentage++;
                break;
            case rarities.epic:
                epicPercentage++;
                break;
            case rarities.legendary:
                legendaryPercentage++;
                break;
        }
        UpdatePercentageTexts();
    }
}
