using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject debugPanel;

    public float ringMass = 5f;
    public float leftForce = 50f;
    public float rightForce = 50f;
    
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
        leftForce = float.Parse(value);
    }
    
    public void SetRightForce(string value)
    {
        rightForce = float.Parse(value);
    }
}
