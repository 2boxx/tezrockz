using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [Header("Ref Card Data")] 
    public CardData cardData;
    
    [Header("Ref Card Renderer")]
    public Image cardFrame;
    public Image cardPortait;
   
    [Header("Ref Card Values")]
    public TextMeshProUGUI cardName;
    public TextMeshProUGUI cardAttack;
    public TextMeshProUGUI cardSpecialAbilities;
    public TextMeshProUGUI cardHP;
    public TextMeshProUGUI cardSP;

    private void Start()
    {
        UpdateDataCard();
    }

    public void UpdateDataCard()
    {
        cardFrame.sprite = cardData.cardFrame;
        cardPortait.sprite = cardData.cardPortait;

        cardName.text = cardData.cardName;
        cardAttack.text = cardData.cardAttack.ToString();
        cardSpecialAbilities.text = cardData.cardSpecialAbilities.ToString();
        cardHP.text = cardData.cardHP.ToString();
        cardSP.text = cardData.cardSP.ToString();
    }
}
