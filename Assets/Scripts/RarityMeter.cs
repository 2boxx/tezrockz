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
        commonText.text = (commonRocks/totalRocks)*100+"%";
        epicText.text = (epicRocks/totalRocks)*100+"%";
        legendaryText.text = (legendaryRocks/totalRocks)*100+"%";
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
