using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class CameraController : MonoBehaviour
{
    private Camera camera = null;
    
    [SerializeField]
    private Sphere sphere = null;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        camera = Camera.main;
        camera.transform.position = new Vector3(10,2,0);
        camera.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
    }

    public void PlayCameraMove()
    {
        var offset = new Vector3(0, 1.5f, -10);
        camera.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        this.UpdateAsObservable().Subscribe(_ =>
        {
            camera.transform.position = sphere.transform.position + offset;
        });
    }
}