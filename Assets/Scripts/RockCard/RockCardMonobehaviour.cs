using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

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
            //curentShape = unitsPerShape.Where(x => x > 0).ToList();
            ChangeCurrentShape();
        }
    }

    public void RandomizeCurrenShape()
    {
        int currentShapeOLD = currentShape;
        ChangeCurrentShape();
       // if(currentShape == currentShapeOLD) ChangeCurrentShape();
    }

    private void ChangeCurrentShape()
    {
        var availableIndexes = new List<int>();
        
        for (int i = 0; i < unitsPerShape.Count; i++)
        {
            if (unitsPerShape[i] > 0)
            {
                availableIndexes.Add(i);
            }
        }

        if (availableIndexes.Count == 0) return;
        currentShape = availableIndexes[Random.Range(0, availableIndexes.Count)];


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
