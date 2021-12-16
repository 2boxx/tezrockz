using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnPlayerWheelMovement : MonoBehaviour
{
    public float maxAngle = 90f;
    public UnityEvent OnPlayerWheelMovementEvent;


    private void Update()
    {

        if (Vector2.Angle(transform.up, Vector3.up) >= maxAngle) {

            OnPlayerWheelMovementEvent.Invoke();
        }

    }
}
