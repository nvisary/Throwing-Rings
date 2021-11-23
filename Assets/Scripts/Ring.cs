using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Ring : MonoBehaviour
{
    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        GetComponent<Rigidbody>().mass = _gameManager ? _gameManager.ringMass : 5f;
    }
    
    private void OnValidate()
    {
        GetComponent<Rigidbody>().mass = _gameManager ? _gameManager.ringMass : 5f;
    }

    public void UpdateMass(float mass)
    {
        GetComponent<Rigidbody>().mass = mass;
    }
}
