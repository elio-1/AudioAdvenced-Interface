using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Vector2 _mouseSensitivity;
    [SerializeField] private Vector2 _padSensitivity;
    [SerializeField] private Vector2 _mouseYLimit;

    private float _horizontal;
    private float _vertical;

    Transform _cameraTransform;
    
    private void Awake()
    {
        _cameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        #region Inputs
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity.x * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")* _mouseSensitivity.y* Time.deltaTime;
        float gamePadX = Input.GetAxis("Horizontal") * _padSensitivity.x * Time.deltaTime;
        float gamePadY = Input.GetAxis("Vertical") * _padSensitivity.y * Time.deltaTime;

        _horizontal += mouseX + gamePadX;
        _vertical += mouseY + gamePadY;
        #endregion
        _vertical = Mathf.Clamp(_vertical, _mouseYLimit.x, _mouseYLimit.y);

        // le joueur tourne sur l'axe x ducoup et la camera tourne surl'axe y /!\
        transform.eulerAngles = new Vector3( transform.eulerAngles.x, _horizontal,transform.eulerAngles.z);
        _cameraTransform.eulerAngles = new Vector3(_vertical, _cameraTransform.eulerAngles.y,_cameraTransform.eulerAngles.z);
    }
}
