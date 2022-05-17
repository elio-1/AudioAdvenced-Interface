using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Interruptor : MonoBehaviour, IUsable
{
    [SerializeField] GameObject _door;
    [SerializeField] Transform _doorStartPos;
    [SerializeField] Transform _doorEndPos;
    [SerializeField] bool _isOpen = false;
    [SerializeField] float _doorMoveSpeed = 1;
    [SerializeField] private AudioMixer _audioMixer ;
    
    private float t;
    private float t2;

    private void Update()
    {
        _door.transform.position = new Vector3(Mathf.Lerp(_doorStartPos.position.x, _doorEndPos.position.x, t), _door.transform.position.y, _door.transform.position.z);
        _audioMixer.SetFloat("LowFreqCutOff", Mathf.Lerp(500, 5000, t2));
        if (_isOpen)
        {
           
            if (t<1)
            {
            t += _doorMoveSpeed * Time.deltaTime;
            t2 += _doorMoveSpeed * Time.deltaTime;

            }
            else
            {
                t = 1;
            }
        }
       else
        {
            if (t>0)
            {
            t -= _doorMoveSpeed * Time.deltaTime;
            t2 -= _doorMoveSpeed * Time.deltaTime;
            }
            else
            {
                t = 0;
            }
        }
    }
    public void Use()
    {
        _isOpen = !_isOpen;
        Debug.Log("Blipbloup!");
    }
}
