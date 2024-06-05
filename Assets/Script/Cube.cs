using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{
    private Transform _transform;

    public event UnityAction<Transform> CleckedCube;

    private void Awake()
    {
        _transform = transform;
    }

    public void ClickOnCube()
    {
        CleckedCube?.Invoke(_transform);
    }

    public void DestroyCube()
    {
        Destroy(gameObject);
    }
}
