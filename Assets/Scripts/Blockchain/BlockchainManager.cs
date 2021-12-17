using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using UnityEngine.Events;

public class BlockchainManager : MonoBehaviour
{
    public TMP_InputField walletInputField;

    public const int contractID = 56434;
    private const string devWalletAdress= "tz1ePwKgTBqNktxSUNQD8mqDFwH9dPPJ21ZG";
    private const string burnWalletAdress = "tz1burnburnburnburnburnburnburjAYjjX";

    public TextMeshProUGUI textFeedback;
    
    public List<Objkt> data;

    public UnityEvent onLoad;
    
    public void GetData() => StartCoroutine(GetData_Coroutine());

    private bool cheatOn = false;
 
    IEnumerator GetData_Coroutine()
    {
        textFeedback.text = "Loading...";
        CheckCheat();
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
                string json = request.downloadHandler.text;
                string address="";

                //Deserialize the data from the JSON
                data = JsonConvert.DeserializeObject<List<Objkt>>(json);
                for (int i = 0; i < data.Count; i++)
                {
                    //Extract the user's collection data we want from the deserialized object
                    int id = data[i].key.nat;
                    int amount = data[i].value;
                    address = data[i].key.address;

                    //Check the user isn't cheating ;)
                    if (!Validate(address))
                    {
                        textFeedback.text = "Nice try! ;)";
                        break;
                    }

                    //Store the user address
                    Inventory.instance.currentWalletAddress = address;
                    
                    //Add the card data to the player inventory singleton
                    Inventory.instance.ownedCards.Clear();
                    for (int j = 0; j < amount; j++)
                    {
                        Inventory.instance.ownedCards.Add(id);
                    }
                }
                if (Validate(address))
                {
                    textFeedback.text = "Success!";
                    onLoad.Invoke();
                }
            }
        }
    }

    //Simple check to prevent the user from playing with the developer or burn address
    private bool Validate(string s)
    {
        if (cheatOn) return true;
        if (s == devWalletAdress || s == burnWalletAdress || s == "")
        {
            return false;
        }
        return true;
    }

    private bool CheckCheat()
    {
        if (walletInputField.text == "moldavita")
        {
            cheatOn = true;
            walletInputField.text = devWalletAdress;
            return true;
        }
        else return false;
    }
}

