using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "tezrockz/RockCardData")]
public class RockCardData : ScriptableObject
{
    public int NFTRockCardID;
    public string name;
    public rarities rarity;
    public int totalEditions;

    public int currentShape = 0;

    public Sprite cardSprite;
//    public List<int> samplesPerShape;
  //  public List<Sprite> shapes;
    public List<Shapes> shapes;
}

public enum rarities
{
    common,
    epic,
    legendary
};


[Serializable]
public struct Shapes
{
    public int samplesPerShape;
    public Sprite shape;

}