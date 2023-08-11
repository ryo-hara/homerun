using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayControlUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI distanceText = null;

    public void SetDistance(float distance)
    {
        distanceText.text = distance.ToString("F2");
    }
    
}
