using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class RockPlacer : MonoBehaviour
{

    [Header("Selected RockCardData")] 
    public RockCardData selectedRockCardData;
    public RockCardMonobehaviour instanceRockCardData;
    public GameObject rockCardPrefabBase;

    private RockCardSelector _rockCardSelector;

    public RarityMeter rarityMeter;
    
    
    [Header("Rock Preview")]
    public GameObject rockPreview;
    public SpriteRenderer rockPrevieSR;
  
    [SerializeField] private Quaternion previewRotation;
    public Color correctPositionColor;
    public Color wrongPositionColor;

    [SerializeField] private GameObject rocksParent;

    [SerializeField] private Vector2 worldPosition2D;

    [SerializeField]
    private float eulerRot;
    [SerializeField] private float rotSpeed;


    public TextMeshProUGUI rockCountText;
    private int _rockCount;
    //[SerializeField] private GameObject pointer;

    public List<GameObject> availableRocks;

    public bool outOfRocks;
    public bool mouseInGame;
    public bool mouseInRock;
    private void Start()
    {
        _rockCardSelector = FindObjectOfType<RockCardSelector>();
        previewRotation = Quaternion.identity;
    }


  
    void SelectNextRock()
    {
        int n = Random.Range(0, availableRocks.Count);
        eulerRot = Random.Range(-5f, 5f);
       
    }
    
    private void Update()
    {
        if (!mouseInGame || outOfRocks)
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
            rarityMeter.totalRocks = _rockCount;
            SelectNextRock();
        }
       
    }

    public void PreviewSelectedRock()//OPTIMIZAR ESTO, ACTUALMENTE SE LLAMA EN UPDATE.
    {
        rockPreview.SetActive(true);
        rockPreview.GetComponent<SpriteRenderer>().sprite = instanceRockCardData.shapes[instanceRockCardData.currentShape];
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
        GameObject newRockGameObject = Instantiate(rockCardPrefabBase, worldPosition2D, previewRotation, rocksParent.transform); //set as type rock?
        newRockGameObject.GetComponent<SpriteRenderer>().sprite = selectedRockCardData.shapes[instanceRockCardData.currentShape];
        instanceRockCardData.SubtractSample(instanceRockCardData.currentShape);
        _rockCardSelector.UpdateCardRockSelected();
        RocksManager.instance.AddRock(newRockGameObject);
        
        if (CheckIfIsLastRockOfTheCard())//Si es la ultima
        {
            Debug.Log("Out of rocks in card: "+instanceRockCardData.name);
            _rockCardSelector.RemoveCurrentCard();
            _rockCardSelector.NextCard();

        }
        
        instanceRockCardData.RandomizeCurrenShape();
        rarityMeter.AddPercentage(instanceRockCardData);

    }

    public bool CheckIfIsLastRockOfTheCard()
    {
        var shapes = instanceRockCardData.unitsPerShape.Where(x => x > 0).ToList();

        return (shapes.Count == 0);

    }
    
    
}
