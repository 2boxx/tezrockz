using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFreezer : MonoBehaviour
{
    public int powers;
    public int initialPowers;
    public LayerMask rocksLayer;

    private void Start()
    {
        powers = initialPowers;
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
            }
        }
    }

    private void Freeze(Rock rock)
    {
        rock.rb.constraints = (RigidbodyConstraints2D.FreezeAll);
        powers--;
    }
}
