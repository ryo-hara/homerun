using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimingAction : MonoBehaviour, IGamePlayAction
{
    [SerializeField]
    private GamePlayControlUI gamePlayControlUI = null;
    [SerializeField]
    private TimingActionUI timingActionUI = null;
    [SerializeField]
    private GameStore gameStore = null;

    private Input input = null;
    private CompositeDisposable disposables = new CompositeDisposable();
    private bool isClicked = false;

    public void Prepare()
    {
        gameStore.StartTimerCount();

        InitializeUI();
        InitializeInput();
    }

    private void InitializeUI()
    {
        timingActionUI.Initialize();

        gameStore.RemainingTimeObservable.Subscribe(time =>
        {
            gamePlayControlUI.SetRemainingTime(time);
        }).AddTo(disposables);
    }

    private void InitializeInput()
    {
        isClicked = false;
        input = GameObject.Find("Input").GetComponent<Input>();
        input.GetKeyPressedObservable(Key.Space).Subscribe(_ =>
        {
            timingActionUI.StopBar();
            var barPosition = timingActionUI.GetBarPositionFromLeftEdge();
            var timingPower = barPosition / 30.0f;
            gameStore.SetClickTiming(timingPower);
            isClicked = true;
        }).AddTo(disposables);
    }

    public void Disable()
    {
        timingActionUI.Finalize();
        disposables.Dispose();
    }
    
    public IEnumerator Execute()
    {
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => isClicked);
        yield return new WaitForSeconds(1);
    }
}

