using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RockParticles : MonoBehaviour
{
    public GameObject hitParticles;


    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 contactPoint = other.contacts[0].point;
        Instantiate(hitParticles, contactPoint, quaternion.identity);
    }
}
