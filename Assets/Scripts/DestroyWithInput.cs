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
        if(destroyAtStart) StartCoroutine(DisableObjectDelay());
        
    }
    
   IEnumerator DisableObjectDelay()
   {
       
       yield return new WaitForSeconds(delay);
       Destroy(gameObject);
    }
}
