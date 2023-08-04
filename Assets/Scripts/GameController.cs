using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> controlList = new List<GameObject>();

    private List<GameObject> instantiateList = new List<GameObject>();
    private List<IGameControl> gameControlList = new List<IGameControl>();
    private void Awake()
    {
        foreach (var control in controlList)
        {
            var instantiateObject = Instantiate(control);
            instantiateObject.SetActive(false);
            gameControlList.Add(instantiateObject.GetComponent<IGameControl>());
            instantiateList.Add(instantiateObject);
        }
        StartCoroutine(ExecControl());
    }
    
    private IEnumerator ExecControl()
    {
        for (int i = 0; i < instantiateList.Count; i++)
        {
            instantiateList[i].SetActive(true);
            yield return gameControlList[i].Execute();
            instantiateList[i].SetActive(false);
        }
        yield return null;
    }
}
