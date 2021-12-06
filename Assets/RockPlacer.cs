using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RockPlacer : MonoBehaviour
{
    [SerializeField] private GameObject selected_rock;

    [SerializeField] private GameObject rocksParent;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 worldPosition2D = new Vector2(worldPosition.x, worldPosition.y);
            var randomRotation = Quaternion.Euler( 0 , 0 , Random.Range(0, 360));
            GameObject newRock = Instantiate(selected_rock, worldPosition2D, randomRotation, rocksParent.transform); //set as type rock?
        }
    }
}
