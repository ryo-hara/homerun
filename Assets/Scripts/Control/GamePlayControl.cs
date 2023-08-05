using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayControl : MonoBehaviour, IGameControl
{
    [SerializeField]
    private List<GameObject> gamePlayActionObjectList = new List<GameObject>();
    private List<IGamePlayAction> gamePlayActionList = new List<IGamePlayAction>();


    private void Awake()
    {
        foreach (var actionObject in gamePlayActionObjectList)
        {
            actionObject.SetActive(false);
            gamePlayActionList.Add(actionObject.GetComponent<IGamePlayAction>());
        }
    }

    public IEnumerator Execute()
    {
        yield return new WaitForSeconds(2);
        yield return ExecuteActions();
        yield return null;
    }

    private IEnumerator ExecuteActions()
    {
        Debug.Log("ExecuteActions");
        for (int i = 0; i < gamePlayActionObjectList.Count; i++)
        {
            gamePlayActionObjectList[i].SetActive(true);
            yield return gamePlayActionList[i].Execute();
            gamePlayActionObjectList[i].SetActive(false);
        }
    }
}
