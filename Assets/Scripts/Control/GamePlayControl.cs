using System.Collections;
using UnityEngine;

public class GamePlayControl : IGameControl
{
    public IEnumerator Execute()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("GamePlayControl");
        yield return null;
    }
}
