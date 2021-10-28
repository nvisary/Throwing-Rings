using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HitForce : MonoBehaviour
{
    private Rigidbody[] _rigidbodies;
    
    [SerializeField]
    private float _force = 50f;

    private bool _isForce = false;
    
    void Start()
    {
        var rings = FindObjectsOfType<Ring>();

        _rigidbodies = rings.Select(ring => ring.GetComponent<Rigidbody>()).ToArray();
    }

    private void FixedUpdate()
    {
        if (_isForce)
        {
            Hit();
        }
    }

    public void EnableForce()
    {
        _isForce = true;
    }

    public void DisableForce()
    {
        _isForce = false;
    }
    

    public void Hit()
    {
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            var position = transform.position;
            
            float distance = Vector3.Distance(position, _rigidbodies[i].transform.position);
            _rigidbodies[i].AddForceAtPosition(transform.up * _force / distance, position);
        }
    }
}
