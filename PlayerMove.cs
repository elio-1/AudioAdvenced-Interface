using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    AudioSource _audioSource;
    CharacterController _characterController;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _audioSource = GetComponentInChildren<AudioSource>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * horizontalInput + transform.forward * verticalInput;
        Vector3 move = direction.normalized * _speed * Time.deltaTime;

        _characterController.Move(move);
        if (direction.magnitude > 0)
        {
            float pitch = _characterController.velocity.magnitude / _speed;
            _audioSource.pitch = Mathf.Clamp(pitch, -3, 3) ;
            _audioSource.Play();
        }
        else
        {
            _audioSource.Pause();
        }
    }
}
