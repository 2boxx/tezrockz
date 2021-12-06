using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.EventSystems;



public class DragDrop : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    

    
     private Vector3 _initialPosition;


     private bool _onDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_onDrag) return;
        
        _initialPosition = transform.position;
        

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _onDrag = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        _onDrag = true;
      
    }

   
}
