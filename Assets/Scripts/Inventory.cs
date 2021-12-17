using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [HideInInspector] public static Inventory instance;

    public List<int> ownedCards; //Static: Everything the user has on the blockchain
    public string currentWalletAddress;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null) instance = this;
        else Destroy(this);
    }

}
