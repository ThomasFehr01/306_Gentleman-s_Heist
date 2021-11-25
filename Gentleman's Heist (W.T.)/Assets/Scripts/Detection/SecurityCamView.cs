using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamView : MonoBehaviour
{
    public LineRenderer tracer;
    public int framesUntilCaught;
    private bool _counting;
    // private PlayerScript _ps;
    private int _intensity = 0;
    // Start is called before the first frame update
    void Start()
    {
        tracer.useWorldSpace = true;
        _counting = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_counting)
        {
            _intensity += 1;
            if (_intensity > framesUntilCaught)
            {
                _intensity = framesUntilCaught;
                PlayerScript.detected = true;
            }
        }
        else
        {
            if (_intensity > 0)
            {
                _intensity -= 2;
            }
        }

        tracer.startColor = new Color(0.5f, 0, 0, _intensity / (float)framesUntilCaught);
        tracer.endColor = new Color(0.5f, 0, 0, _intensity / (float)framesUntilCaught);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _counting = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _counting = false;
            tracer.SetPosition(0, tracer.gameObject.transform.position);
            tracer.SetPosition(1, tracer.gameObject.transform.position);
        }
        
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tracer.SetPosition(0, tracer.gameObject.transform.position);
            tracer.SetPosition(1, other.gameObject.transform.position);
        }
    }
}
