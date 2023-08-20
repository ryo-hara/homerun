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

    [SerializeField]
    private CameraController cameraController = null;

    private Input input = null;
    private CompositeDisposable disposables = new CompositeDisposable();
    private bool isSphereOnFloor = false;

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
        Debug.Log("FlyAction");
        yield return ExecSphereMove();
        yield return new WaitForSeconds(100);
    }
    
    private IEnumerator ExecSphereMove()
    {
        yield return new WaitForSeconds(0.5f);
        cameraController.PlayCameraMove();

        var collisionFloor = false;

        sphere.CollisionFloorObservable.Subscribe(_ =>
        {
            collisionFloor = true;
        });

        yield return new WaitUntil(() => collisionFloor);
        yield return new WaitForSeconds(0.5f);
    }
}
