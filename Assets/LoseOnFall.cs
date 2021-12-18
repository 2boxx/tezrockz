using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseOnFall : MonoBehaviour
{
    private int count;
    public int limit;

    public GameManager gameManager;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        count++;
        if (count >= limit && !gameManager.debug_CannotLose) gameManager.OnLoseGame.Invoke();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        count--;
    }
}
