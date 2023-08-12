using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class BarMoveAction : MonoBehaviour, IGamePlayAction
{
    [SerializeField]
    private GameStore gameStore = null;
    [SerializeField]
    private Bar bar = null;
    [SerializeField]
    private Sphere sphere = null;

    [SerializeField]
    private CameraController cameraController = null;

    private bool isSphereOnFloor = false;

    private CompositeDisposable disposables = new CompositeDisposable();

    public void Prepare()
    {
        bar.SphereColliderObservable.Subscribe(_ =>
        {
            StartCoroutine(ExecSphereMove());
        }).AddTo(disposables);
    }

    public void Disable()
    {
        disposables.Dispose();
    }

    public IEnumerator Execute()
    {
        yield return new WaitForSeconds(1);
        bar.BarMove();
        yield return new WaitUntil(() => isSphereOnFloor);
    }

    private IEnumerator ExecSphereMove()
    {
        sphere.AddForce(gameStore.GetPowerMagnification());
        yield return new WaitForSeconds(0.5f);
        cameraController.PlayCameraMove();

        var collisionFloor = false;
        sphere.CollisionFloorObservable.Subscribe(_ =>
        {
            collisionFloor = true;
        });

        yield return new WaitUntil(() => collisionFloor);
        yield return new WaitForSeconds(0.5f);
        isSphereOnFloor = true;
    }
}
