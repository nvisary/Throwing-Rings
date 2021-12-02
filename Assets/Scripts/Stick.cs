using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Stick : MonoBehaviour
{

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _gameManager.AddPoint();
    }

    private void OnTriggerExit(Collider other)
    {
        _gameManager.RemovePoint();
    }
}
