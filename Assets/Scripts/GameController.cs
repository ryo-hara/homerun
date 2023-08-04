using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private List<IGameControl> controlList = new List<IGameControl>();

    private void Awake()
    {
        controlList.Add(new TitleControl());
        controlList.Add(new GamePlayControl());
        controlList.Add(new ResultControl());
        StartCoroutine(ExecControl());
    }
    
    private IEnumerator ExecControl()
    {
        foreach (var control in controlList)
        {
            yield return control.Execute();
        }

        yield return null;
    }
}
