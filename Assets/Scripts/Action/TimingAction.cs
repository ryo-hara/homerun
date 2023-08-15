using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimingAction : MonoBehaviour, IGamePlayAction
{
    [SerializeField]
    private TimingActionUI timingActionUI = null;
    [SerializeField]
    private GameStore gameStore = null;

    private Input input = null;
    private CompositeDisposable disposables = new CompositeDisposable();
    private bool isClicked = false;

    public void Prepare()
    {
        isClicked = false;
        timingActionUI.Initialize();
        
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

