using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Rock : MonoBehaviour
{
 
    SpriteRenderer _rend;

    private Rigidbody2D _rb;

    public bool useJointSystem = true;

    public bool hasJoint;

    public PhysicsMaterial2D physicsMat;
    
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        
        gameObject.AddComponent<PolygonCollider2D>();
        GetComponent<ResizePolygonCollider2D>().ResizeCollider();
        GetComponent<PolygonCollider2D>().sharedMaterial = physicsMat;
    }

    private void Update()
    {
        if (_rend.isVisible)
        {
            _rb.bodyType  = RigidbodyType2D.Dynamic;
        }
        else
        {
            _rb.bodyType  = RigidbodyType2D.Static;

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (useJointSystem == false) return;
        
        if (other.gameObject.CompareTag("Rock"))
        { 
            if (hasJoint) return;
            
            if (other.gameObject.GetComponent<Rigidbody2D>())
            {
                hasJoint = true;
                HingeJoint2D  joint = gameObject.AddComponent(typeof(HingeJoint2D )) as HingeJoint2D ;
                joint.connectedBody = other.gameObject.GetComponent<Rigidbody2D>();
                joint.enableCollision = true;
                joint.breakForce = 100f;
                joint.useLimits = true;
                JointAngleLimits2D limits = joint.limits;
              //  limits.min = 0;
               // limits.max = 0;
                joint.limits = limits;
     

            }
              
        }
    }
}
