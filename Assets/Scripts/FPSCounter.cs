using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{

    private int _screenLongSide;
    private Rect _boxRect;
    private GUIStyle _guiStyle = new GUIStyle();

    private int _frameCount;
    private float _elapsedTime;
    private double _frameRate;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        UpdateUISize();
    }

    private void UpdateUISize()
    {
        _screenLongSide = Mathf.Max(Screen.width, Screen.height);
        Debug.Log(_screenLongSide);
        float rectLongSide = _screenLongSide / 10f;
        _boxRect = new Rect(rectLongSide, 1, rectLongSide, rectLongSide / 3);
        _guiStyle.fontSize = (int) (_screenLongSide / 36.8f);
        _guiStyle.normal.textColor = Color.white;
    }
    

    // Update is called once per frame
    private void Update()
    {
        _frameCount++;
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > 0.5f)
        {
            _frameRate = System.Math.Round(_frameCount / _elapsedTime, 1, System.MidpointRounding.AwayFromZero);
            _frameCount = 0;
            _elapsedTime = 0;

            if (_screenLongSide != Mathf.Max(Screen.width, Screen.height))
            {
                UpdateUISize();
            }
        }
    }

    private void OnGUI()
    {
        GUI.Box(_boxRect, "");
        GUI.Label(_boxRect, " " + _frameRate + "fps", _guiStyle);
    }
}
