using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCardMonobehaviour : MonoBehaviour
{
    public RockCardData myData;
    
    public int NFTRockCardID;
    public string name;
    public rarities rarity;
    public int totalEditions;
    
    public int currentShape = 0;

    public Sprite cardSprite;
    public List<Shapes> shapes;

    private void Start()
    {
        UpdateCardData();
    }


    public void UpdateCardData()
    {
        NFTRockCardID = myData.NFTRockCardID;
        name = myData.name;
        rarity = myData.rarity;
        totalEditions = myData.totalEditions;
        cardSprite = myData.cardSprite;
        shapes = myData.shapes;
        currentShape = myData.currentShape;
    }
    
}
