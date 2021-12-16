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

    public Sprite rockpreview;
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

public struct Shapes
{
    public int samplesPerShape;
    public Sprite shape;

}