using System;
using TMPro;
using UnityEngine;

public class GamePlayControlUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI distanceText = null;
    
    [SerializeField]
    private TextMeshProUGUI remainingTimeText = null;


    public void SetDistance(float distance)
    {
        distanceText.text = distance.ToString("F2");
    }

    public void SetRemainingTime(float time)
    {
        // Note: 0秒未満が入るケースがあるので、0以下を出さないようにする
        remainingTimeText.text = Math.Max(time, 0.0f).ToString("F2");
    }
    
    public void SetRemainingTimeTextActive(bool active)
    {
        // Note: 0秒未満が入るケースがあるので、0以下を出さないようにする
        remainingTimeText.gameObject.SetActive(active);
    }
}
