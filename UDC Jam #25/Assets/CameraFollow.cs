using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float offset;

    Vector3 newPos;

    private void Update()
    {
        newPos = new Vector3(target.transform.position.x, target.transform.position.y, -offset);
    }

    private void LateUpdate()
    {
        transform.position = newPos;
    }
}
