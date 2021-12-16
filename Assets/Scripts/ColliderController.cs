using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    private PolygonCollider2D _collider;
    public float rescaleFactor = 0.02f;
    private void Awake()
    {
        
        _collider = GetComponent<PolygonCollider2D>();

        RescaleCollider(0.001f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            RescaleCollider(rescaleFactor);
                Debug.Log("RescaleCollider");

        }
    }

    void RescaleCollider(float size)
    {
        for (int i = 0; i < _collider.points.Length; i++)
        {
            _collider.points[i].x -= size;
            _collider.points[i].y -= size;
        }
 
    }
}
