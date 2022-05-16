using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    CharacterController _characterController;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * horizontalInput + transform.forward * verticalInput;
        Vector3 move = direction.normalized * _speed * Time.deltaTime;

        _characterController.Move(move);
    }
}
