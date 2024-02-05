using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float CameraRotationSpeedX;
    public float CameraRotationSpeedY;
    public float MinRotationAngleY;
    public float MaxRotationAngleY;

    public Transform CameraYAxisTransform;

    void Start()
    {
        
    }

    void Update()
    {
        transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y + CameraRotationSpeedX * Input.GetAxis("Mouse X") * Time.deltaTime, 0f);

        var _newXRotation = CameraYAxisTransform.localEulerAngles.x - CameraRotationSpeedY * Input.GetAxis("Mouse Y") * Time.deltaTime;
        if (_newXRotation > 180) _newXRotation -= 360;
        _newXRotation = Mathf.Clamp(_newXRotation, MinRotationAngleY, MaxRotationAngleY);

        CameraYAxisTransform.localEulerAngles = new Vector3(_newXRotation, 0f, 0f);
    }
}
