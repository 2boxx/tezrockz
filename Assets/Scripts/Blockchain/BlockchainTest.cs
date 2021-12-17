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
    
    public List<String> parsedStringTest;

    public TextMeshProUGUI testOutput;

    public TextMeshProUGUI testParsedCards;

    //public CardCollection cardCollection;

    private List<string> cards;

    public TextMeshProUGUI textWalletAdress;

    private bool isValidWallet = true;
    
    const char charCardDelimiters = '{';

    public List<Root> data;
    
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
                
                //JSON Test
                string s = request.downloadHandler.text;
                Debug.Log("Json Input String: " + s);
                data = JsonConvert.DeserializeObject<List<Root>>(s);
                for (int i = 0; i < data.Count; i++)
                {
                    Debug.Log("Card #" + i);
                    Debug.Log("Key:");
                    Debug.Log("address: " + data[i].key.address);
                    Debug.Log("nat: " + data[i].key.nat); //Id of this card
                    Debug.Log("Value:"); //Amount of this card
                    Debug.Log(data[i].value);

                    int id = data[i].key.nat;
                    int amount = data[i].value;
                    
                    Inventory.instance.ownedCards.Clear();
                    for (int j = 0; j < amount; j++)
                    {
                        Inventory.instance.ownedCards.Add(id);
                    }
                }
            }
        }
    }
}

