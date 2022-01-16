using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARPlaneManager))]
public class ARPlaneController : MonoBehaviour
{
    private ARPlaneManager planeManager;

    private void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
    }

    private void Update()
    {
        if (planeManager.enabled)
        {
            PlaneVisibleActive(false);
        }
        else
        {
            return;
        }
    }

    private void PlaneVisibleActive(bool value)
    {
        foreach(var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }
}
