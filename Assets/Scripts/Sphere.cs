using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody = null;
    public void AddForce()
    {
        var force = new Vector3(0,10,20);
        rigidbody.AddForce(force, ForceMode.Impulse);
    }
    
}
