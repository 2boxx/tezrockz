using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RocksManager : MonoBehaviour
{
    private List<GameObject> activeRocks;
    public static RocksManager instance;
    
    private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(this);
        activeRocks = new List<GameObject>();
    }


    public void AddRock(GameObject rock)
    {
        activeRocks.Add(rock);
    }

    public GameObject GetHighestRock()
    {
        if (activeRocks.Count < 1) return null;
        return activeRocks.OrderByDescending(go => go.transform.position.y).First();
    }
}
