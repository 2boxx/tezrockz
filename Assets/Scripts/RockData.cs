using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rocks/Rock")]
public class RockData : ScriptableObject
{
    public int id;
    public string name;
    public rarities rarity;
    public int totalEditions;
    //public float price;

    public Sprite preview;
    public Sprite cardSprite;
    public List<int> samplesPerShape;
    public List<Sprite> shapes;
}

public enum rarities
{
    common,
    epic,
    legendary
};
