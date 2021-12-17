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

    public int contractID = 56434; // 56434 = tezrocks
    
    // public List<String> parsed;

    public TextMeshProUGUI testOutput;

    public TextMeshProUGUI testParsedCards;

    //public CardCollection cardCollection;

    private List<string> cards;

    public TextMeshProUGUI textWalletAdress;

    private bool isValidWallet = true;
    
    public void GetData() => StartCoroutine(GetData_Coroutine());
 
    IEnumerator GetData_Coroutine()
    {
        textWalletAdress.text = walletInputField.text;
        testOutput.text = "Loading...";
        string uri = "https://api.tzkt.io/v1/bigmaps/"+contractID.ToString()+"/keys?key.address="+walletInputField.text+"&select=key,value";
        //https://api.tzkt.io/v1/bigmaps/56434/keys?key.address=tz1ePwKgTBqNktxSUNQD8mqDFwH9dPPJ21ZG&select=key,value
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError || request.downloadHandler.text == "[]")
            {
                testOutput.text = request.error;
                isValidWallet = false;
            }
            else
            {
                isValidWallet = true;
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
                cards = ParseCollection(request.downloadHandler.text);
                foreach (var c in cards)
                {
                    testParsedCards.text += c;
                    testParsedCards.text += "\n";
                }

                testOutput.text = "";

                for (int i = 0; i < cards.Count; i++)
                {
                    testOutput.text += "Card " + i;
                    testOutput.text += "\n";
                    // testOutput.text += cards[i].ToString();

                    List<string> parsedCard = ParseCard(cards[i]);
                    foreach (var s in parsedCard)
                    {
                        testOutput.text += "\n";
                        testOutput.text += s;
                        testOutput.text += "\n";
                    }
                    testOutput.text += "\n";
                    testOutput.text += "\n";
                }
            }
        }
    }

    List<string> ParseObjktIDs(string input)
    {
        List<string> parsed = new List<string>();
        parsed.Clear();
        string[] substrings = input.Split('"');
        for (int i = 3; i < substrings.Length-1; i+=8) //i+=8)
        {
            parsed.Add(substrings[i]);
        }

        return parsed;
    }

    List<string> ParseCollection(string input) // Recorre cada carta (sin importar si tenes muchas ediciones de una)
    {
        List<string> cards = new List<string>();
        string[] substrings = input.Split(']');
        for (int i = 0; i < substrings.Length-1; i++)
        {
            cards.Add(substrings[i]);
        }

        Inventory.instance.Clear();
        return cards;
    }

    List<string> ParseCard(string input) //Recorre dentro de la carta y extrae el ID y el numero de ediciones
    {
        Debug.Log("Parse Card input:" + input);
        List<string> parsed = new List<string>();
        parsed.Clear();
        string[] substrings = input.Split('"');
        parsed.Add("ID: " + substrings[5]);
        parsed.Add("Quantity: " + substrings[13]);

        Inventory.instance.ownedCards[int.Parse(substrings[5])] = int.Parse(substrings[13]);
        
        return parsed;
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
