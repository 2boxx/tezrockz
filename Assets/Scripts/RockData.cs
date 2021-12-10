using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rocks/Rock")]
public class RockData : ScriptableObject
{
    public int id;
    public string name;
    public rarities rarity;
    public float price;
    
}

public enum rarities
{
    normal,
    epic,
    mega,
    legendary,
    gamer
};
