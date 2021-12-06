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

    public int score = 0;

    [SerializeField]
    private GameObject ringPrefab;

    [SerializeField] 
    private int maxRings = 20;
    
    public Rigidbody[] rigidbodies;
    
    // UI 
    public Text countRingsText;
    public Text scoreText;
    
    private void Awake()
    {
        rigidbodies = new Rigidbody[maxRings];
    }

    private void Start()
    {
        // TODO: How to define how frame rate set? may be can set 120 fps, but in 60hz displays not needed
        Application.targetFrameRate = 60; 
        
        // TODO: For Debug Mode, create level system, please
        AddRing();
    }

    public void AddRing()
    {
        if (countRings >= maxRings) return;
        
        GameObject ring = Instantiate(ringPrefab);
        Rigidbody ringRigidBody = ring.GetComponent<Rigidbody>();
        
        ringRigidBody.mass = ringMass;
        
        rigidbodies[countRings++] = ringRigidBody;
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
        Debug.Log("SetRingMass");
        if (float.TryParse(value, out ringMass))
        {
            Debug.Log("Updated " + this.ToString());

            for (int i = 0; i < rigidbodies.Length; i++)
            {
                rigidbodies[i].mass = ringMass;
            }       
        }
    }
    
    public void SetLeftForce(string value)
    {
        leftForce = float.Parse(value);
    }
    
    public void SetRightForce(string value)
    {
        rightForce = float.Parse(value);
    }

    private void UpdateScoreText()
    {
        // TODO: Create Static class to manipulate texts on UI
        scoreText.text = "Score: " + score;
    }

    public void AddPoint()
    {
        score++;
        UpdateScoreText();
    }

    public void RemovePoint()
    {
        score--;
        UpdateScoreText();
    }
}
