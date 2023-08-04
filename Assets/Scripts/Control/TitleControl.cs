using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleControl : GameControl
{
    public IEnumerator Execute()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("TitleControl");
        yield return null;
    }
}
