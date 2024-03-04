using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSourceRotation : MonoBehaviour
{
    public float TargetInSkyDistance;

    public Transform TargetPointTransform;

    public Camera Camera;

    private void Update()
    {


        var ray = Camera.ViewportPointToRay(new Vector3(0.5f, 0.7f, 0f));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) TargetPointTransform.position = hit.point;
        else TargetPointTransform.position = ray.GetPoint(TargetInSkyDistance);

        transform.LookAt(TargetPointTransform.position);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
