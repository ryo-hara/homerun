using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingAction : MonoBehaviour, IGamePlayAction
{
    public void Prepare()
    {
    }

    public void Disable()
    {
    }
    
    public IEnumerator Execute()
    {
        yield return new WaitForSeconds(5);
    }

}

