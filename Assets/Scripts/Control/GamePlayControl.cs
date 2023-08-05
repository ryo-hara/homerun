using System.Collections;
using UnityEngine;

public class GamePlayControl : MonoBehaviour, IGameControl
{
    public IEnumerator Execute()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("GamePlayControl");
        yield return null;
    }
}