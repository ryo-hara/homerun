using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class BarMoveAction : MonoBehaviour, IGamePlayAction
{
    [SerializeField]
    private Bar bar = null;

    private bool isSphereOnFloor = false;

    private CompositeDisposable disposables = new CompositeDisposable();

    public void Prepare()
    {
    }

    public void Disable()
    {
        disposables.Dispose();
    }

    public IEnumerator Execute()
    {
        yield return new WaitForSeconds(1);
        bar.BarMove();
        var onEnterCollisionSphere = false;
        bar.SphereColliderObservable.Subscribe(_ =>
        {
            onEnterCollisionSphere = true;
        }).AddTo(disposables);

        yield return new WaitUntil(() => onEnterCollisionSphere);
    }
}
