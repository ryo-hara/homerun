using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMoveAction : MonoBehaviour, IGamePlayAction
{
    [SerializeField]
    private Bar bar = null;

    [SerializeField]
    private Sphere sphere = null;
    
    public IEnumerator Execute()
    {
        yield return new WaitForSeconds(1);
        bar.BarMove();
        Debug.Log("BarMoveAction");
        yield return null;
    }
}
