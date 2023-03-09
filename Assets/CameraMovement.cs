using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform followTarget;

    void Update()
    {
        transform.position = new Vector3(followTarget.position.x, transform.position.y, transform.position.z);
    }
}
