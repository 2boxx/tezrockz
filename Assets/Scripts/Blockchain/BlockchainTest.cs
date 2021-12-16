using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;


public class BlockchainTest : MonoBehaviour
{
    // public string currentWallet = "tz1brgKFnJLYa5xNw96sYo4Bt9oeDcwHU62R";
    public TMP_InputField walletInputField;

    public int contractID = 511;
    
    public List<String> parsed;

    public TextMeshProUGUI testOutput;

    public TextMeshProUGUI testParsedCards;

    public CardCollection cardCollection;
    
    public void GetData() => StartCoroutine(GetData_Coroutine());
 
    IEnumerator GetData_Coroutine()
    {
        testOutput.text = "Loading...";
        string uri = "https://api.tzkt.io/v1/bigmaps/"+contractID.ToString()+"/keys?key.address="+walletInputField.text+"&select=key,value";
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                testOutput.text = request.error;
            else
            {
                //SUCCESS
                
                //TEST ONE
                // testOutput.text = "";
                // List<string> objktIDs = ParseObjktIDs(request.downloadHandler.text);
                // foreach (var s in objktIDs)
                // {
                //     testOutput.text += s;
                //     testOutput.text += "\n";
                // }
                //
                
                //TEST TWO
                testParsedCards.text = "";
                List<string> cards = ParseCollection(request.downloadHandler.text);
                foreach (var c in cards)
                {
                    testParsedCards.text += c;
                    testParsedCards.text += "\n";
                }
            }
        }
    }

    List<string> ParseObjktIDs(string input)
    {
        parsed = new List<string>();
        parsed.Clear();
        string[] substrings = input.Split('"');
        for (int i = 3; i < substrings.Length-1; i+=8) //i+=8)
        {
            parsed.Add(substrings[i]);
        }

        return parsed;
    }

    List<string> ParseCollection(string input)
    {
        List<string> cards = new List<string>();
        string[] substrings = input.Split(']');
        for (int i = 0; i < substrings.Length-1; i++)
        {
            cards.Add(substrings[i]);
        }

        return cards;
    }
}

// line 5 = id #1
// line 13 = quantity #1
// 14 empty
// 15 start over (add 16
//
//
//
// 5, 13
// 21, 29
// 37, 45
