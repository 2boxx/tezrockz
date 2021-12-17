using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;


public class BlockchainManager : MonoBehaviour
{
    public TMP_InputField walletInputField;

    public const int contractID = 56434;

    private const string devWalletAdress= "tz1ePwKgTBqNktxSUNQD8mqDFwH9dPPJ21ZG";

    private const string burnWalletAdress = "tz1burnburnburnburnburnburnburjAYjjX";

    public List<String> parsedStringTest;

    public TextMeshProUGUI textFeedback;

    private List<string> cards;

    public TextMeshProUGUI textWalletAdress;
    
    public List<Root> data;
    
    public void GetData() => StartCoroutine(GetData_Coroutine());
 
    IEnumerator GetData_Coroutine()
    {
        textWalletAdress.text = walletInputField.text;
        textFeedback.text = "Loading...";
        string uri = "https://api.tzkt.io/v1/bigmaps/"+contractID.ToString()+"/keys?key.address="+walletInputField.text+"&select=key,value";
        //https://api.tzkt.io/v1/bigmaps/56434/keys?key.address=tz1ePwKgTBqNktxSUNQD8mqDFwH9dPPJ21ZG&select=key,value
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError || request.downloadHandler.text == "[]")
            {
                textFeedback.text = request.error;
            }
            else
            {
                //Get the user input
                string s = request.downloadHandler.text;

                //Check the user isn't cheating ;)
                s = Validate(s);

                //Deserialize the data from the JSON
                data = JsonConvert.DeserializeObject<List<Root>>(s);
                for (int i = 0; i < data.Count; i++)
                {
                    //Extract the user's collection data we want from the deserialized object
                    int id = data[i].key.nat;
                    int amount = data[i].value;
                    
                    //Store the user address
                    Inventory.instance.currentWalletAddress = data[i].key.address;
                    
                    //Add the card data to the player inventory singleton
                    Inventory.instance.ownedCards.Clear();
                    for (int j = 0; j < amount; j++)
                    {
                        Inventory.instance.ownedCards.Add(id);
                    }
                }
            }
        }
    }

    private string Validate(string s)
    {
        if (s == devWalletAdress || s == burnWalletAdress) return "nice try! :)";
        if (s == "moldavita") return devWalletAdress;
        return s;
    }
}

