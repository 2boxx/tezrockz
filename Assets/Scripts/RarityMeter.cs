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
    
    public int commonRocks;
    public int epicRocks;
    public int legendaryRocks;

    public int totalRocks;

    public void UpdatePercentageTexts()
    {
        if (totalRocks == 0 ) return;
        commonText.text = commonRocks*100/totalRocks+"%";
        epicText.text =  epicRocks*100/totalRocks+"%";
        legendaryText.text =  legendaryRocks*100/totalRocks+"%";
    }


    public void AddPercentage(RockCardMonobehaviour rock)
    {
        switch (rock.rarity)
        {
            case rarities.common:
                commonRocks++;
                break;
            case rarities.epic:
                epicRocks++;
                break;
            case rarities.legendary:
                legendaryRocks++;
                break;
        }
        totalRocks++;
        UpdatePercentageTexts();
    }
}
