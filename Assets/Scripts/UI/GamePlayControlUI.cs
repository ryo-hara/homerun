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
        remainingTimeText.text = time.ToString("F2");
    }
}
