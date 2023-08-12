using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody = null;

    private Subject<Unit> collisionFloorSubject = new Subject<Unit>();
    public IObservable<Unit> CollisionFloorObservable => collisionFloorSubject;

    public void OnCollisionEnter(Collision collision)
    {
        var floor = collision.gameObject.GetComponent<Floor>();
        if (floor != null)
        {
            collisionFloorSubject.OnNext(Unit.Default);
        }
    }

    public void AddForce(float magnification)
    {
        var force = new Vector3(0,10,20) * magnification;
        rigidbody.AddForce(force, ForceMode.Impulse);
    }

    public IObservable<Vector3> GetPositionObservable()
    { 
        return transform.ObserveEveryValueChanged(transform_ => transform_.position);
    }
    
}
