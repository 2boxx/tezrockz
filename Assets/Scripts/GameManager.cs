using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] Cards;
    public Transform[] Positions;
    public Transform StartPosition;
    public List<GameObject> ActiveCards = new List<GameObject>();
    public TextMeshProUGUI WalletText;
    public TMP_InputField SendString;


    public UnityEvent OnFinishedGame;
    // Start is called before the first frame update
    void Start()
    {
    //DisconnectWallet();
    //ResetCards(); 
     
     Application.targetFrameRate = 60;

    }
    public void ResetCards(){
         for(int i = 0; i < Cards.Length; i++)
        {
        // Cards[i].SetActive(false);
        Cards[i].transform.position = StartPosition.position;
        }
    }
    public void ConnectWallet(string walletCode ){
        WalletText.text = walletCode;
    }
    public void DisconnectWallet(  ){
        WalletText.text = "Sync Wallet";
    }
    
    public void UpdateCards(){
        for(int i = 0; i < ActiveCards.Count ; i++){ 
            Debug.Log(i + " " + ActiveCards[i] + " " + ActiveCards.IndexOf(ActiveCards[i]) );
            StartCoroutine(LerpPosition( System.Array.IndexOf(Cards, ActiveCards[i])  , Positions[ActiveCards.IndexOf(ActiveCards[i])].position, 0.2f));
        }
            
    }
    public void LocalAddCard(InputField SendString){
        // Debug.Log(SendString.text);
        if(SendString.text != null){

        AddCard(SendString.text);
        }
    }
    public void AddCard( string codeSent ){
        
       int whichCard = int.Parse(codeSent.Substring(0, 1) )-1;
       if(Positions.Length >ActiveCards.Count ){
           SlideCardIn(whichCard);
            ActiveCards.Add(Cards[whichCard]);
        }
    }
    public void RemoveCard( int whichCard ){  
        if(ActiveCards.Count >0 && ActiveCards.Contains(Cards[whichCard]) ){
            ActiveCards.Remove(Cards[whichCard]);
            SlideCardOut(whichCard);  
            UpdateCards();
        }
    }
    public void SlideCardIn(int whichCard ){
      StartCoroutine(LerpPosition( whichCard, Positions[ActiveCards.Count].position, 0.2f));        
    }
    public void SlideCardOut(int whichCard ){
        StartCoroutine(LerpPosition( whichCard, StartPosition.position, 0.2f));    
    }
    IEnumerator LerpPosition(int whichCard, Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition =  Cards[whichCard].transform.position;

        while (time < duration)
        {
            Cards[whichCard].transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }

    public void FinishedGame()
    {
        OnFinishedGame.Invoke();
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


