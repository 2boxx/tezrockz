using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class BlockchainTest : MonoBehaviour
{
    // public string currentWallet = "tz1brgKFnJLYa5xNw96sYo4Bt9oeDcwHU62R";
    public TMP_InputField walletInputField;

    public int contractID = 511;
    
    public List<String> parsed;

    public TextMeshProUGUI testOutput;
 
    public void GetData() => StartCoroutine(GetData_Coroutine());
 
    IEnumerator GetData_Coroutine()
    {
        testOutput.text = "Loading...";
        //Obtener y reemplazar por wallet del usuario // Extraer address
        string uri = "https://api.tzkt.io/v1/bigmaps/"+contractID.ToString()+"/keys?key.address="+walletInputField.text+"&select=key";
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                testOutput.text = request.error;
            else
            {
                testOutput.text = "";
                List<string> objktIDs = ParseObjktIDs(request.downloadHandler.text);
                foreach (var s in objktIDs)
                {
                    testOutput.text += s;
                    testOutput.text += "\n";
                }
            }
        }
    }

    List<string> ParseObjktIDs(string input)
    {
        parsed = new List<string>();
        parsed.Clear();
        string[] substrings = input.Split('"');
        for (int i = 3; i < substrings.Length-1; i+=8)
        {
            parsed.Add(substrings[i]);
        }

        return parsed;
    }
}
