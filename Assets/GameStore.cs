using UnityEngine;

public class GameStore : MonoBehaviour
{
    private int rendaCount = 0;
    private float clickTiming = 0;

    public void SetClickTiming(float timing)
    {
        clickTiming = timing;
    }

    public void SetRendaCount(int count)
    {
        rendaCount = count;
    }

    public float GetPowerMagnification()
    {
        return clickTiming * (float)rendaCount / 30;
    }
}
