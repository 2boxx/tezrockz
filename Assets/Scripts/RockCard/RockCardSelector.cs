using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Object = System.Object;
using Random = UnityEngine.Random;


public class RockCardSelector : MonoBehaviour
{
    private GameManager _gm;
    private RockPlacer _rockPlacer;

    public bool loadNFTInventory;
    
    [Header("Select Preview")]
    public Image selectedRockImage;
    public TextMeshProUGUI samplesPerShapeText;
    

    [Header("Player Rocks")]
    public List<int> rockCardsTokensPlayer;//Las cartas que tiene le jugador, esto lo llenamos con la ID que obtengamos del getToken
    public List<RockCardMonobehaviour> rockCardsPlayer;//En base a rockCardsToken, esto lo rellenamos con las cartas que tenga.
  
    [Header("Rock Cards Glossary")]
    public List<RockCardData> rockCardsGlossary;//Todas las cartas del juego.


    private void Start()
    {
        if (loadNFTInventory) //cargamos los nft de la wallet
            rockCardsTokensPlayer = Inventory.instance.ownedCards;
            
            
        _gm = FindObjectOfType<GameManager>();
        _rockPlacer = FindObjectOfType<RockPlacer>();
        CheckPlayerTokens();
        UpdateCardRockSelected();
    }

    public void CheckPlayerTokens()
    {
        foreach (var rockCardToken in rockCardsTokensPlayer)
        {
            foreach (var rockCardTokenGlossary in rockCardsGlossary)
            {
                if (rockCardToken == rockCardTokenGlossary.NFTRockCardID)
                {
                    var newCard = new GameObject("PlayerCard"+rockCardTokenGlossary.name); 
                    var component = newCard.AddComponent<RockCardMonobehaviour>();
                    component.myData = rockCardTokenGlossary;
                    component.UpdateCardData();
                    
                    rockCardsPlayer.Add(component);

                }
            }
        }
    }
    
    [SerializeField] int _cardIndex=0;
    public void NextCard()
    {
        _cardIndex++;
        if (_cardIndex >= rockCardsPlayer.Count)  _cardIndex = 0;

        CheckIfIOutOfCards();
        UpdateCardRockSelected();
    }
    public void PreviousCard()
    {
        _cardIndex--;
        if (_cardIndex <= 0)  _cardIndex = rockCardsPlayer.Count-1;
        
        CheckIfIOutOfCards();
        UpdateCardRockSelected();
    }

    public void RemoveCurrentCard()
    {
        rockCardsPlayer.RemoveAt(_cardIndex);
    }
    public void UpdateCardRockSelected()
    {
        if (_rockPlacer.outOfRocks) return;
        
        var newCard = rockCardsPlayer[_cardIndex];
        //Actualizamos el preview de la seleccion
        selectedRockImage.sprite = newCard.shapes[0];

        var sum = newCard.unitsPerShape.Aggregate(0,(acum,current) => acum + current);//Cantidad total de unidades de rocas que quedan en esa carta
        samplesPerShapeText.text = sum.ToString();
      
        //Actualizamos la info de la roca que esta usando el jugador
        _rockPlacer.instanceRockCardData = rockCardsPlayer[_cardIndex];
        _rockPlacer.selectedRockCardData = newCard.myData;
    }

    public void CheckIfIOutOfCards()
    {
        if (rockCardsPlayer.Count == 0)
        {
            _rockPlacer.outOfRocks = true;
            _gm.FinishedGame();
            
            Debug.Log("Out of cards");
        }
    }
   
}

