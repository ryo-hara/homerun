using System;
using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class FlyAction : MonoBehaviour, IGamePlayAction
{
    
    [SerializeField]
    private GamePlayControlUI gamePlayControlUI = null;
    
    [SerializeField]
    private Sphere sphere = null;

    private Input input = null;
    private CompositeDisposable disposables = new CompositeDisposable();

    public void Prepare()
    {
        sphere.GetPositionObservable().Subscribe(position =>
        {
            gamePlayControlUI.SetDistance(position.z);
        }).AddTo(disposables);
    }

    public void Disable()
    {
        disposables.Dispose();
    }

    public IEnumerator Execute()
    {
        // Note: ボールを飛ばす処理を入れる
        Debug.Log("FlyAction");
        yield return new WaitForSeconds(100);
    }
}
