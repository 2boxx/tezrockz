using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
// [System.Serializable]
// public class CardCollectionData
// {
//    public List<Root> data;
// }

[System.Serializable]
public class Key
{
   public int nat { get; set; }
   public string address { get; set; }
}

[System.Serializable]
public class Root
{
   public Key key { get; set; }
   public int value { get; set; }
}




