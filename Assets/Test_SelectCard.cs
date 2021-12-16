using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_SelectCard : MonoBehaviour
//PLACEHOLDER -- TEST CLASS DESIGNED FOR TESTING UI ONLY
{
    private Card card;

    private void Awake()
    {
        card = GetComponent<Card>();
    }

    public void LoadTestCardData(Card selectedCard)
    {
        card.cardData = selectedCard.cardData;
        card.UpdateDataCard();
    }
}
