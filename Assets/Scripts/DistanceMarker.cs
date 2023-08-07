using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceMarker : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro distanceText = null;

    public void SetText(string text)
    {
        distanceText.text = text;
    }
    
    // Update is called once per frame
    void Update()
    {
        var position = Camera.main.transform.position;
        position.y = transform.position.y;
        transform.LookAt (position);
        
        // カメラよりも後ろに行ったら非表示
    }
}
