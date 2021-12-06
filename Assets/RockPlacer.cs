using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RockPlacer : MonoBehaviour
{
    [SerializeField] private GameObject selectedRockPrefab;

    [SerializeField] private GameObject rocksParent;

    [SerializeField] private GameObject rockPreview;
    [SerializeField] private Vector2 worldPosition2D;
    [SerializeField] private Quaternion previewRotation;

    private void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition2D = new Vector2(worldPosition.x, worldPosition.y);
        
        if (Input.GetMouseButton(1))
        {
            var randomRotation = Quaternion.Euler( 0 , 0 , Random.Range(0, 360));
            GameObject newRock = Instantiate(selectedRockPrefab, worldPosition2D, randomRotation, rocksParent.transform); //set as type rock?
        }

        PreviewSelectedRock();
    }

    public void PreviewSelectedRock()
    {
        rockPreview.transform.position = worldPosition2D;
        rockPreview.transform.rotation = previewRotation;
    }
}
