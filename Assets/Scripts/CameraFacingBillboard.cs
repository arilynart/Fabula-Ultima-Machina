using UnityEngine;
using System.Collections;

public class CameraFacingBillboard : MonoBehaviour
{
    private Camera m_Camera;
    private SpriteRenderer renderer;

    private void Awake()
    {
        m_Camera = Camera.main;
        renderer = GetComponent<SpriteRenderer>();
        renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
    }

    //Orient the camera after all movement is completed this frame to avoid jittering
    void LateUpdate()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
        renderer.sortingOrder = -Mathf.FloorToInt(transform.position.z);
    }
}