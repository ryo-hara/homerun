using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarObject : MonoBehaviour
{
    public Action<Collider> onTriggerEnterAction = null;
    public void OnTriggerEnter(Collider other)
    {
        onTriggerEnterAction?.Invoke(other);
    }
}
