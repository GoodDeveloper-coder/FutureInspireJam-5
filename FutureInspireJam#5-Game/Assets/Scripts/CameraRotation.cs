using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float _sensitivity;
    private float _verticalRotation;

    void Start()
    {
        StartCoroutine(CameraBobbing());    
    }

    void Update()
    {
        _verticalRotation -=  Input.GetAxis("Mouse Y") * _sensitivity;
        _verticalRotation = Math.Clamp(_verticalRotation, -60, 90);
        transform.localEulerAngles = new Vector3(_verticalRotation, transform.localEulerAngles.y, transform.localEulerAngles.z);

        transform.parent.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * _sensitivity, 0);

        Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator CameraBobbing()
    {
        transform.DOLocalMoveY(transform.localPosition.y - 0.05f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        transform.DOLocalMoveY(transform.localPosition.y + 0.05f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(CameraBobbing());
    }

    void OnDisable()
    {
        StopCoroutine(CameraBobbing());
        Cursor.lockState = CursorLockMode.None;
    }
}
