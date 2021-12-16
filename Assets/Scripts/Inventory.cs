using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [HideInInspector] public static Inventory instance;
    public const int maxCards = 128;
    
    public List<int> ownedCards; //Static: Everything the user has on the blockchain
    public List<int> activeCards; //Dynamic: The current inventory that is being used
    //This should be a dictionary
    
    
    private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(this);
        Clear();
    }

    public void Clear()
    {
        Inventory.instance.ownedCards.Clear();
        Inventory.instance.ownedCards = new List<int>(maxCards);
        for (int i = 0; i < Inventory.maxCards-1; i++)
        {
            Inventory.instance.ownedCards.Add(0);
        }
    }

}
