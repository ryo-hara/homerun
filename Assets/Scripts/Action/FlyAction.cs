using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAction : MonoBehaviour, IGamePlayAction
{
    public IEnumerator Execute()
    {
        yield return null;
    }
}
