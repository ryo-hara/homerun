using System.Collections;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class RendaAction : MonoBehaviour, IGamePlayAction
{

    [SerializeField]
    private GamePlayControlUI gamePlayControlUI = null;
    [SerializeField]
    private GameStore gameStore = null;
    [SerializeField]
    private RendaActionUI rendaActionUI = null; 
    
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
        gameStore.StopTimerCount();
        disposables.Dispose();
    }

    public IEnumerator Execute()
    {
        onInputReception = true;
        yield return new WaitUntil( () => gameStore.isTimeOver());
        gamePlayControlUI.SetRemainingTimeTextActive(false);
        gameStore.SetRendaCount(inputCount);
    }

    private void Initialize()
    {
        onInputReception = false;
        inputCount = 0;
        
        rendaActionUI.Initialize();
        InitializeRemainingTimeUI();

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
    
    private void InitializeRemainingTimeUI()
    {
        gameStore.RemainingTimeObservable.Subscribe(time =>
        {
            gamePlayControlUI.SetRemainingTime(time);
        }).AddTo(disposables);
    }

    private void UpdateCount()
    {
        if (onInputReception)
        {
            inputCount++;
            rendaActionUI.UpdateCount(inputCount);
        }
    }
}
