using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject debugPanel;

    public float ringMass = 5f;
    public float leftForce = 50f;
    public float rightForce = 50f;

    public int countRings = 0;

    [SerializeField]
    private GameObject ringPrefab;

    [SerializeField] 
    private int maxRings = 20;
    
    public Rigidbody[] rigidbodies;
    
    // UI 
    public Text countRingsText; 
    
    private void Awake()
    {
        rigidbodies = new Rigidbody[maxRings];
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        AddRing();
    }

    public void AddRing()
    {
        if (countRings >= 10) return;
        GameObject ring = Instantiate(ringPrefab);
        rigidbodies[countRings++] = ring.GetComponent<Rigidbody>();
        countRingsText.text = countRings.ToString();
    }

    public void RemoveRing()
    {
        if (countRings <= 0) return;
        Destroy(rigidbodies[countRings - 1].gameObject);
        countRings--;
        countRingsText.text = countRings.ToString();
    }

    public void EnableDebugPanel()
    {
        debugPanel.SetActive(true);
    }

    public void DisableDebugPanel()
    {
        debugPanel.SetActive(false);   
    }

    public void SetRingMass(string value)
    {
        ringMass = float.Parse(value);
    }
    
    public void SetLeftForce(string value)
    {
        Debug.Log("updated" + float.Parse(value));
        leftForce = float.Parse(value);
    }
    
    public void SetRightForce(string value)
    {
        rightForce = float.Parse(value);
    }
}
