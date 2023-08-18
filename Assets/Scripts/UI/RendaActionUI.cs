using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RendaActionUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI rendaCount = null;

    private const string COUNT_TEXT = " count";
    
    public void Initialize()
    {
        UpdateCount(0);
    }
    
    public void UpdateCount(int count)
    {
        rendaCount.text = count + COUNT_TEXT;
    }
}
