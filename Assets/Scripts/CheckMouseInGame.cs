using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckMouseInGame : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    RockPlacer _rockPlacer;

   private void Awake()
   {
       _rockPlacer = FindObjectOfType<RockPlacer>();
   }

  

   public void OnPointerEnter(PointerEventData eventData)
   {
       _rockPlacer.mouseInGame = true;
   }

   public void OnPointerExit(PointerEventData eventData)
   {
       _rockPlacer.mouseInGame = false;
   }
}
