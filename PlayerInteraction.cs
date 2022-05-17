using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 10;
    [SerializeField] private Image _crosshair;
    private IUsable _target;
    private Transform _cameraTransform;
    private void Awake()
    {
        _cameraTransform = Camera.main.transform;
        
    }
    void Update()
    {
        FindTarget();
        UseTarget();
        ChangeCrossHairState();
        Debug.DrawRay(_cameraTransform.transform.position, _cameraTransform.forward * _maxDistance, Color.red);
    }

    private void FindTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(_cameraTransform.transform.position, _cameraTransform.forward, out hit, _maxDistance))
        {
            _target = hit.collider.GetComponent<IUsable>();
        }
        else
        {
            _target = null;
        }
        
    }
    private void UseTarget()    
    {
        if (Input.GetKeyDown(KeyCode.E) && _target != null)
        {
            _target.Use();
        }
    }
    private void ChangeCrossHairState()
    {
        if (_target != null)
        {
            _crosshair.color = Color.red;
        }
        else
        {
            _crosshair.color = Color.white;

        }
    }

}
