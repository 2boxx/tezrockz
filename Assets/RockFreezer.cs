using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using UnityEngine.Events;

public class RockFreezer : MonoBehaviour
{
    private int powers;
    public int initialPowers;
    public LayerMask rocksLayer;
    public Color frozenColor;

    public TextMeshProUGUI UI_powerCounter;

    public GameObject frozenParticles;

    public UnityEvent onReward;

    private void Start()
    {
        powers = initialPowers;
        UpdateUI();
        GameManager.instance.rockFreezer = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (powers <= 0) return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, rocksLayer);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                Rock selectedRock = hit.collider.gameObject.GetComponent<Rock>();
                Freeze(selectedRock);
                Instantiate(frozenParticles, selectedRock.transform.position, quaternion.identity);
            }
        }
    }

    private void Freeze(Rock rock)
    {
        powers--;
        rock.rb.constraints = (RigidbodyConstraints2D.FreezeAll);
        rock.sprite.color = frozenColor;
        UpdateUI();
    }

    void UpdateUI()
    {
        UI_powerCounter.text = "Freezes: " + powers.ToString();
    }

    public void AddReward()
    {
        powers += 1;
        onReward.Invoke();
        UpdateUI();
    }
}
