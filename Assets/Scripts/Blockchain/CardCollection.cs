using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardCollection
{
    const int maxID = 64;
    // public List<int> cardsInCollection;
    public Dictionary<int, int> cards;
}


