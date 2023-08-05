using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Bar : MonoBehaviour
{
    [SerializeField]
    private BarObject barObject;

    [SerializeField]
    private CameraController cameraController;

    [SerializeField]
    private Vector3 rotate = new Vector3(-90, 0, 0);

    [SerializeField]
    private int rotateFrame = 60;
    
    private float ROTATE_INTERVAL = 1.0f;

    private IDisposable disposable = null;
    
    void Start()
    {
        // barObject.onTriggerEnterAction = (collider) =>
        // {
        //     var component = collider.GetComponent<Sphere>();
        //     if (component != null)
        //     {
        //         component.AddForce();
        //         StartCoroutine(cameraController.playCameraNove());
        //     }
        // };
    }

    public void BarMove()
    {
        var nowRotate = transform.rotation.eulerAngles;
        var rotateDiff = rotate - nowRotate;
        var updateRotate = rotateDiff / rotateFrame;

        var frame = 0;
        disposable = this.UpdateAsObservable().Subscribe(_ =>
        {
            frame++;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + updateRotate);
            if (frame >= rotateFrame)
            {
                disposable?.Dispose();
            }
        });
    }
    
}
