using System;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float _sensitivity;
    private float _verticalRotation;

    void Start()
    {
        
    }

    void Update()
    {
        _verticalRotation -=  Input.GetAxis("Mouse Y") * _sensitivity;
        _verticalRotation = Math.Clamp(_verticalRotation, -30, 60);
        transform.localEulerAngles = new Vector3(_verticalRotation, transform.localEulerAngles.y, transform.localEulerAngles.z);

        transform.parent.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * _sensitivity, 0);

        Cursor.lockState = CursorLockMode.Locked;
    }
}
