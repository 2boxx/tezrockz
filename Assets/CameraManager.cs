using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private RocksManager _rocksManager;
    [SerializeField] private GameObject cameraTarget;

    private void LateUpdate()
    {
        if (_rocksManager.GetHighestRock()!=null)
            cameraTarget.transform.position = _rocksManager.GetHighestRock().gameObject.transform.position;
    }
}
