using UnityEngine;

public class GameStore : MonoBehaviour
{
    private int rendaCount = 0;

    public void SetRendaCount(int count)
    {
        rendaCount = count;
    }

    public float GetPowerMagnification()
    {
        return (float)rendaCount / 30;
    }
}
