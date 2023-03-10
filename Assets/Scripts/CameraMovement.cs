using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform followTarget;
    public Transform lookTarget;

    private Vector3 offset = new Vector3(0, 8, -16);

    private static bool CameraLock;
    public static CameraState State;

    private Vector3 zoom3Offset = new Vector3(12, 4, 0);

    public enum CameraState
    {
        DEFAULT,
        ZOOM1,
        ZOOM2,
        ZOOM3
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) StartCoroutine(CameraZoom3());

        if (!CameraLock)
        {
            transform.position = new Vector3(followTarget.position.x + offset.x, followTarget.position.y + offset.y, followTarget.position.z + offset.z);
        }
    }

    IEnumerator CameraZoom3()
    {
        CameraLock = true;
        float time = 0;
        float swerveDuration = 0.7f;
        float panDuration = 2f;
        iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(followTarget.position.x + zoom3Offset.x, followTarget.position.y + zoom3Offset.y, followTarget.position.z + zoom3Offset.z), "time", swerveDuration, "easetype", iTween.EaseType.linear));
        
        while (time <= swerveDuration)
        {
            //iTween.MoveUpdate(gameObject, new Vector3(followTarget.position.x + zoom3Offset.x, followTarget.position.y + zoom3Offset.y, followTarget.position.z + zoom3Offset.z), swerveDuration);
            iTween.LookUpdate(gameObject, lookTarget.position, swerveDuration);
            time += Time.deltaTime;
            yield return null;
        }
        float targetz = transform.position.z + 2f;
        
        time = 0;
        iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(transform.position.x, transform.position.y, targetz), "time", panDuration, "easetype", iTween.EaseType.linear));
        while (time <= panDuration)
        {
            //iTween.MoveUpdate(gameObject, new Vector3(transform.position.x, transform.position.y, targetz), panDuration);
            time += Time.deltaTime;
            yield return null;
        }
        iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(followTarget.position.x + offset.x, followTarget.position.y + offset.y, followTarget.position.z + offset.z), "time", swerveDuration, "easetype", iTween.EaseType.linear));
        iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(27, 0, 0), "time", swerveDuration, "easetype", iTween.EaseType.linear));
        time = 0;
        while (time <= swerveDuration)
        {
            time += Time.deltaTime;
            yield return null;
        }
        CameraLock = false;
    }
}
