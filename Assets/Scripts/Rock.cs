using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Rock : MonoBehaviour
{
    public RockData rockData;
    SpriteRenderer _rend;

    private Rigidbody2D _rb;

    public bool hasJoint;
    
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_rend.isVisible)
        {
            _rb.isKinematic = false;
        }
        else
        {
            _rb.isKinematic = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Rock"))
        { 
            if (hasJoint) return;
            
            if (other.gameObject.GetComponent<Rigidbody2D>())
            {
                hasJoint = true;
                HingeJoint2D  joint = gameObject.AddComponent(typeof(HingeJoint2D )) as HingeJoint2D ;
                joint.connectedBody = other.gameObject.GetComponent<Rigidbody2D>();
                joint.enableCollision = true;
                joint.breakForce = 150f;
     

            }
              
        }
    }
}
