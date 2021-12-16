using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "ScriptableObjects/Card", order = 1)]
public class CardData : ScriptableObject
//TO DO:rename this to CardData
{
   [Header("Card Sprites")]
   public Sprite cardFrame;
   public Sprite cardPortait;
   
   [Header("Card Values")]
   public string cardName;
   public int cardAttack;
   public int cardSpecialAbilities;
   public int cardHP;
   public int cardSP;

   
}
