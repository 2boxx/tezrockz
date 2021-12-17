using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class RockFreezer : MonoBehaviour
{
    private int powers;
    public int initialPowers;
    public LayerMask rocksLayer;
    public Color frozenColor;

    public TextMeshProUGUI UI_powerCounter;

    public GameObject frozenParticles;
    private void Start()
    {
        powers = initialPowers;
        UpdateUI();
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

    public void RewardPowers()
    {
        powers += 1;
        UpdateUI();
    }
}
