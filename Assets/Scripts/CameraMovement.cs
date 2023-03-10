using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform followTarget;

    public Vector3 offset = new Vector3(0, 5, -5);

    void Update()
    {
        transform.position = new Vector3(followTarget.position.x + offset.x, followTarget.position.y + offset.y, followTarget.position.z + offset.z);
    }
}
