using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_WalletText : MonoBehaviour
{
    public TextMeshProUGUI UI_Wallet;

    private void Start()
    {
        LoadCurrentWalletText();
    }

    public void LoadCurrentWalletText()
    {
        if (Inventory.instance.currentWalletAddress != "")
        {
            UI_Wallet.text = Inventory.instance.currentWalletAddress;            
        }
        else
        {
            UI_Wallet.text = "Error! No Wallet";
        }
    }
}
