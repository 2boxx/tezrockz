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

 
   private void OnTriggerStay2D(Collider2D other)
   {

       if (other.CompareTag("Rock"))
       {
      //     Debug.Log("Rock");
           _rockPlacer.mouseInRock = true;
       }
       else if(other.CompareTag("Zone_Game"))
       {
//           Debug.Log("Not rock");

           _rockPlacer.mouseInRock = false;
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
