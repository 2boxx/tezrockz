using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RocksManager : MonoBehaviour
{
    public List<Rock> activeRocks;

    public void Add(Rock rock)
    {
        activeRocks.Add(rock);
    }
}
