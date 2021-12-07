using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private RocksManager _rocksManager;
    [SerializeField] private GameObject cameraTarget;
    public float minimumY = 0f;

    private void LateUpdate()
    {
        
        if (_rocksManager.GetHighestRock() == null) return;
        Transform highestRockTransform = _rocksManager.GetHighestRock().gameObject.transform;
        if (highestRockTransform.position.y < minimumY) return;
        cameraTarget.transform.position =
            new Vector3(
                cameraTarget.transform.position.x,
                highestRockTransform.position.y,
                cameraTarget.transform.position.z);
    }
}
