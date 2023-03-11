using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraMovement : MonoBehaviour
{
    public Transform followTarget;
    public Transform zoomTarget;

    private Vector3 offset = new Vector3(0, 8, -16);

    private static bool CameraLock;

    private Vector3 zoom3Offset = new Vector3(12, 4, 2f);

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
        iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(zoomTarget.transform.position.x + zoom3Offset.x, zoomTarget.transform.position.y + zoom3Offset.y, zoomTarget.transform.position.z + zoom3Offset.z), "time", swerveDuration, "easetype", iTween.EaseType.easeInQuad));
        iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(10f, -90f, -1f), "time", swerveDuration, "easetype", iTween.EaseType.easeInCubic));
        while (time <= swerveDuration)
        {
            time += Time.deltaTime;
            yield return null;
        }
        float targetz = transform.position.z - 2f;
        
        time = 0;
        iTween.MoveTo(gameObject, iTween.Hash("position", new Vector3(transform.position.x, transform.position.y, targetz), "time", panDuration, "easetype", iTween.EaseType.linear));
        while (time <= panDuration)
        {
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
