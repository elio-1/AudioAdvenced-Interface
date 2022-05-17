using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoLight : MonoBehaviour
{
    [SerializeField] Light _light;
    [SerializeField] float _rate;
    float timer;
    void Start()
    {
        timer = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > _rate)
        {
            _light.color = Color.red;
            if (timer>_rate*2)
            {
                _light.color = Color.green;
                if (timer > _rate * 2.5f)
                {
                    _light.color = Color.blue;
                    if (timer > _rate * 3)
                    {
                        _light.color = Color.yellow;
                        if (timer > _rate*3.5)
                        {
                            timer = 0;
                        }
                    }
                }
            }
        }
        

    }
}
