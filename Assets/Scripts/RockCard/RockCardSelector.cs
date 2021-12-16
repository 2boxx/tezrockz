using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Object = System.Object;
using Random = UnityEngine.Random;


public class RockCardSelector : MonoBehaviour
{
    private GameManager _gm;
    private RockPlacer _rockPlacer;
    
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
        if (_cardIndex == rockCardsPlayer.Count)  _cardIndex -=1;
        
        UpdateCardRockSelected();
    }
    public void PreviousCard()
    {

        _cardIndex--;
        if (_cardIndex <= 0)  _cardIndex = 0;
        
        UpdateCardRockSelected();
    }


    public void UpdateCardRockSelected()
    {
        selectedRockImage.sprite =   rockCardsPlayer[_cardIndex].shapes[0].shape;
        samplesPerShapeText.text = "x"+rockCardsPlayer[_cardIndex].shapes[0].samplesPerShape.ToString();
        _rockPlacer.selectedRockCardData = rockCardsPlayer[_cardIndex].myData;

    }
}

