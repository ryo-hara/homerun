using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceAction : MonoBehaviour, IGamePlayAction
{
    [SerializeField]
    private GameStore gameStore = null;
    
    [SerializeField]
    private Sphere sphere = null;

    public void Prepare()
    {
    }

    public void Disable()
    {
    }
    
    public IEnumerator Execute()
    {
        sphere.AddForce(gameStore.GetPowerMagnification());
        yield return null;
    }
}
