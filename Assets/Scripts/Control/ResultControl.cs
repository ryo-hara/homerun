using System.Collections;
using UnityEngine;

public class ResultControl : MonoBehaviour, IGameControl
{
    public IEnumerator Execute()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("ResultControl");
        yield return null;
    }
}
