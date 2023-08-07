using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceMarkerGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject distanceMarkerPrefab = null;

    private readonly Vector3 MARKER_DISTANCE = new Vector3(-5,0, 10);
    private const int MAX_MARKER_NUM = 10;
    private void Awake()
    {
        for (var i = 0; i < MAX_MARKER_NUM; i++)
        {
            var generatedObject = Instantiate(distanceMarkerPrefab, transform);
            generatedObject.transform.position = new Vector3(-5, 0, 10 * (i+1));
            var text = (i + 1) * 10 + "m";
            generatedObject.GetComponent<DistanceMarker>().SetText(text);
        }
    }
}
