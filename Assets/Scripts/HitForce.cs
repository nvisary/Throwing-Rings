using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class HitForce : MonoBehaviour
{
    private Rigidbody[] _rigidbodies;
    private GameManager _gameManager;
    
    [SerializeField]
    private ForceDirection _forceDirection;
    
    public enum ForceDirection
    {
        Left, Right
    }
    
    private bool _isForce = false;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
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
        var force = _forceDirection == ForceDirection.Left ? _gameManager.leftForce : _gameManager.rightForce; 
        for (int i = 0; i < _gameManager.countRings; i++)
        {
            var position = transform.position;
            
            float distance = Vector3.Distance(position, _gameManager.rigidbodies[i].transform.position);
            _gameManager.rigidbodies[i].AddForceAtPosition(transform.up * force / distance, position);
        }
    }
}
