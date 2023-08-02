using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera camera = null;
    
    [SerializeField]
    private Sphere sphere = null;

    
    void Start()
    {

        StartCoroutine(playCameraNove());
    }

    private IEnumerator playCameraNove()
    {
        yield return new WaitForSeconds(0.5f);


        var offset = new Vector3(0, 1.5f, -10);

        this.UpdateAsObservable().Subscribe(_ =>
        {
            camera.transform.position = sphere.transform.position + offset;
        
        });
        
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}