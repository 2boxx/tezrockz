using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckMouseInGame : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    RockPlacer _rockPlacer;
    public bool checkWithCollider;
    
   private void Awake()
   {
       _rockPlacer = FindObjectOfType<RockPlacer>();
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.CompareTag("Rock"))
       {
           _rockPlacer.mouseInGame = false;
       }
   }
   private void OnTriggerExit2D(Collider2D other)
   {
       if (!other.CompareTag("Rock"))
       {
           _rockPlacer.mouseInGame = true;
       }
   }

   public void OnPointerEnter(PointerEventData eventData)
   {
       if (checkWithCollider) return;
       
       _rockPlacer.mouseInGame = true;
   }

   public void OnPointerExit(PointerEventData eventData)
   {
       if (checkWithCollider) return;

       _rockPlacer.mouseInGame = false;
   }
}
