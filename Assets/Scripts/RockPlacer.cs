using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class RockPlacer : MonoBehaviour
{
    [SerializeField] private GameObject selectedRockPrefab;

    [SerializeField] private GameObject rocksParent;

    public GameObject rockPreview;
    [SerializeField] private Vector2 worldPosition2D;

    [SerializeField]
    private float eulerRot;
    [SerializeField] private Quaternion previewRotation;
    [SerializeField] private float rotSpeed;

    public bool mouseInGame;

    public TextMeshProUGUI rockCountText;
    private int _rockCount;
    //[SerializeField] private GameObject pointer;

    public List<GameObject> availableRocks;

    private void Start()
    {
        SetupPreview();
        previewRotation = Quaternion.identity;
        
    }

    void SetupPreview()
    {
        rockPreview = Instantiate(selectedRockPrefab);
        rockPreview.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0.5f);
        rockPreview.GetComponent<Rigidbody2D>().isKinematic = true;
        rockPreview.GetComponent<Collider2D>().enabled = false;
    }

    void UpdatePreview()
    {
        rockPreview.GetComponent<SpriteRenderer>().sprite = selectedRockPrefab.GetComponent<SpriteRenderer>().sprite; //OPTIMIZE THIS!!
    }

    void SelectNextRock()
    {
        int n = Random.Range(0, availableRocks.Count);
        selectedRockPrefab = availableRocks[n];
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
        
        if (Input.GetMouseButtonDown(0))
        {
            SpawnRock();
            _rockCount++;
            rockCountText.text = _rockCount.ToString();
            SelectNextRock();
        }
;
        //Store a rotation and update it based on mousewheel...
//        Debug.Log("Input.GetAxis(Mouse ScrollWheel) = " + Input.GetAxis("Mouse ScrollWheel"));
        eulerRot = eulerRot + (Input.GetAxis("Mouse ScrollWheel") + Input.GetAxis("Horizontal")) * rotSpeed * Time.deltaTime;
        previewRotation =  quaternion.Euler(0f, 0f, eulerRot);
       
        //and show the preview.
        PreviewSelectedRock();
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

    void SpawnRock()
    {
        var randomRotation = Quaternion.Euler( 0 , 0 , Random.Range(0, 360));
        GameObject newRockGameObject = Instantiate(selectedRockPrefab, worldPosition2D, previewRotation, rocksParent.transform); //set as type rock?
        RocksManager.instance.AddRock(newRockGameObject);
    }


}
