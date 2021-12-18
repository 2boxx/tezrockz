using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rock"))
        {
            Destroy(gameObject);
            GameManager.instance.rockFreezer.AddReward();
        }
    }
}
