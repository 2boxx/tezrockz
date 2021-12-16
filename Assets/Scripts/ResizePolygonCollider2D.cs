using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizePolygonCollider2D : MonoBehaviour
{
    [SerializeField][Range(-1,1f)]
    private float m_scale = 0.1f; // scale setting
 
    private PolygonCollider2D m_polygonCollider;
    private Vector2[] m_path; // original path


    private void Awake()
    {
        m_polygonCollider = GetComponent<PolygonCollider2D>();
        m_path = m_polygonCollider.GetPath(0);
 
        m_polygonCollider.SetPath(0, ScalePath(m_scale));
    }


 
    
    private Vector2[] ScalePath(float scale)
    {
        var scaledPath = new List<Vector2>();
        for (int i = 0; i <  m_path.Length; i++)
        {
            Vector2 p1 = m_path[i]; // first point
            Vector2 p2 = m_path[(i + 1) % m_path.Length]; // next
 
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;
 
            var n = new Vector2(dy, -dx).normalized; // normalize for uniform effect
 
            scaledPath.Add(p1 + n * scale);
        }

 
        return scaledPath.ToArray();
    }
}
