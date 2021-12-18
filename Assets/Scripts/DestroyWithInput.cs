using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithInput : MonoBehaviour
{


     public bool destroyAtStart;
    public float delay;

    private void Start()
    {
        if(destroyAtStart) StartCoroutine(DestroyObjectDelay());
        
    }


    public void DestroyInnmediate()
    {
        Destroy(gameObject);
    }
    
   IEnumerator DestroyObjectDelay()
   {
       
       yield return new WaitForSeconds(delay);
       Destroy(gameObject);
    }
}
