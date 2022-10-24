using System;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform target;

    void Start()
    {
        transform.parent = null;
    }

    void LateUpdate()
    {
        if (target)
        {
            transform.position = target.position;
        }
    }
}