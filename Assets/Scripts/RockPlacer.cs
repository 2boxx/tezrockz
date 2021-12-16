using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class RockPlacer : MonoBehaviour
{
    
    [Header("Rock Preview")]
    public GameObject rockPreview;
    public SpriteRenderer rockPrevieSR;
    [SerializeField] private Quaternion previewRotation;
    public Color correctPositionColor;
    public Color wrongPositionColor;
    
    [SerializeField] private GameObject selectedRockPrefab;

    [SerializeField] private GameObject rocksParent;

    [SerializeField] private Vector2 worldPosition2D;

    [SerializeField]
    private float eulerRot;
    [SerializeField] private float rotSpeed;


    public TextMeshProUGUI rockCountText;
    private int _rockCount;
    //[SerializeField] private GameObject pointer;

    public List<GameObject> availableRocks;

    public bool mouseInGame;
    public bool mouseInRock;
    private void Start()
    {
        previewRotation = Quaternion.identity;
    }


    void UpdatePreview()
    {
        rockPrevieSR.sprite = selectedRockPrefab.GetComponent<SpriteRenderer>().sprite; //OPTIMIZE THIS!!
    }

    void SelectNextRock()
    {
        int n = Random.Range(0, availableRocks.Count);
        selectedRockPrefab = availableRocks[n];
        eulerRot = Random.Range(-5f, 5f);
        UpdatePreview();
    }
    
    private void Update()
    {
        if (!mouseInGame)
        {
            DisablePreviewRock(); return;
        }

      
        
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition2D = new Vector2(worldPosition.x, worldPosition.y);
;
        //Store a rotation and update it based on mousewheel...
//        Debug.Log("Input.GetAxis(Mouse ScrollWheel) = " + Input.GetAxis("Mouse ScrollWheel"));
        eulerRot = eulerRot + (Input.GetAxis("Mouse ScrollWheel") + Input.GetAxis("Horizontal")) * rotSpeed * Time.deltaTime;
        previewRotation =  quaternion.Euler(0f, 0f, eulerRot);
        
        //and show the preview.
        PreviewSelectedRock();
        if (mouseInRock)
        {
            ChanguePreviewRockColor(wrongPositionColor); return;
        }
        
        ChanguePreviewRockColor(correctPositionColor);
        
        if (Input.GetMouseButtonDown(0))
        {
            SpawnRock();
            _rockCount++;
            rockCountText.text = _rockCount.ToString();
            SelectNextRock();
        }
       
    }

    public void PreviewSelectedRock()
    {
        rockPreview.SetActive(true);
        rockPreview.transform.position = worldPosition2D;
        rockPreview.transform.rotation = previewRotation;
    }
    public void DisablePreviewRock()
    {
        rockPreview.SetActive(false);
    }
    
    public void ChanguePreviewRockColor(Color color)
    {
        rockPrevieSR.color = color;
    }

    void SpawnRock()
    {
        var randomRotation = Quaternion.Euler( 0 , 0 , Random.Range(0, 360));
        GameObject newRockGameObject = Instantiate(selectedRockPrefab, worldPosition2D, previewRotation, rocksParent.transform); //set as type rock?
        RocksManager.instance.AddRock(newRockGameObject);
    }


}
