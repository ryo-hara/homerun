using System;
using System.Collections;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class RendaAction : MonoBehaviour, IGamePlayAction
{

    [SerializeField]
    private TextMeshProUGUI rendaCunt = null; 
    
    private Input input = null;
    private bool onInputReception = false;
    private int inputCount = 0;
    
    private CompositeDisposable disposables = new CompositeDisposable();

    public void Prepare()
    {
        Initialize();
    }

    public void Disable()
    {
        disposables.Dispose();
    }

    public IEnumerator Execute()
    {
        onInputReception = true;
        yield return new WaitForSeconds(5);
    }

    private void Initialize()
    {
        onInputReception = false;
        inputCount = 0;
        rendaCunt.text = "0 count";

        input = GameObject.Find("Input").GetComponent<Input>();
        input.GetKeyPressedObservable(Key.A).Subscribe(_ =>
        {
            UpdateCount();
        }).AddTo(disposables);
        
        input.GetKeyPressedObservable(Key.L).Subscribe(_ =>
        {
            UpdateCount();
        }).AddTo(disposables);
    }

    private void UpdateCount()
    {
        if (onInputReception)
        {
            inputCount++;
            rendaCunt.text = inputCount + " count";
        }
    }
}
