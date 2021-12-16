using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public List<int> unitsPerShape;
    public List<Sprite> shapes;
    private void Start()
    {
        UpdateCardData();
    }

    public void SubtractSample(int index)
    {
        unitsPerShape[index] -= 1;
        if (unitsPerShape[index] <= 0)//Si se acabaron las unidades de esa forma, cambiamos el currenShape
        {
            currentShape = unitsPerShape.Where(x => x > 0).ToList().Count;
        }
    }
    

    public void UpdateCardData()
    {
        NFTRockCardID = myData.NFTRockCardID;
        name = myData.name;
        rarity = myData.rarity;
        totalEditions = myData.totalEditions;
        cardSprite = myData.cardSprite;
        unitsPerShape = new List<int>(myData.unitsPerShape);
        shapes = new List<Sprite>(myData.shapes); 
        currentShape = myData.currentShape;
    }
    
}
