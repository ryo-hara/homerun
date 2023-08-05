using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> controlList = new List<GameObject>();

    private List<IGameControl> gameControlList = new List<IGameControl>();
    private void Awake()
    {
        foreach (var control in controlList)
        {
            control.SetActive(false);
            gameControlList.Add(control.GetComponent<IGameControl>());
        }
        StartCoroutine(ExecControl());
    }
    
    private IEnumerator ExecControl()
    {
        for (int i = 0; i < controlList.Count; i++)
        {
            controlList[i].SetActive(true);
            yield return gameControlList[i].Execute();
            controlList[i].SetActive(false);
        }
    }
}
