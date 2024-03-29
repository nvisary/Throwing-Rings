﻿using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AnchorGameObject : MonoBehaviour
{
    public enum AnchorType
    {
        BottomLeft,
        BottomCenter,
        BottomRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        TopLeft,
        TopCenter,
        TopRight,
    };
    
    public enum Orientation
    {
        Width, Height, NotChange
    }

    public bool executeInUpdate;

    public AnchorType anchorType;
    public Orientation orientation;
    public Vector3 anchorOffset;

    IEnumerator _updateAnchorRoutine; //Coroutine handle so we don't start it if it's already running

    // Use this for initialization
    void Start()
    {
        _updateAnchorRoutine = UpdateAnchorAsync();
        StartCoroutine(_updateAnchorRoutine);
    }

    /// <summary>
    /// Coroutine to update the anchor only once CameraFit.Instance is not null.
    /// </summary>
    IEnumerator UpdateAnchorAsync()
    {

        uint cameraWaitCycles = 0;

        while (CameraViewportHandler.Instance == null)
        {
            ++cameraWaitCycles;
            yield return new WaitForEndOfFrame();
        }

        if (cameraWaitCycles > 0)
        {
            print(string.Format("CameraAnchor found CameraFit instance after waiting {0} frame(s). " +
                "You might want to check that CameraFit has an earlie execution order.", cameraWaitCycles));
        }

        UpdateAnchor();
        _updateAnchorRoutine = null;

    }

    void UpdateAnchor()
    {
        switch (anchorType)
        {
            case AnchorType.BottomLeft:
                SetAnchor(CameraViewportHandler.Instance.BottomLeft);
                break;
            case AnchorType.BottomCenter:
                SetAnchor(CameraViewportHandler.Instance.BottomCenter);
                break;
            case AnchorType.BottomRight:
                SetAnchor(CameraViewportHandler.Instance.BottomRight);
                break;
            case AnchorType.MiddleLeft:
                SetAnchor(CameraViewportHandler.Instance.MiddleLeft);
                break;
            case AnchorType.MiddleCenter:
                SetAnchor(CameraViewportHandler.Instance.MiddleCenter);
                break;
            case AnchorType.MiddleRight:
                SetAnchor(CameraViewportHandler.Instance.MiddleRight);
                break;
            case AnchorType.TopLeft:
                SetAnchor(CameraViewportHandler.Instance.TopLeft);
                break;
            case AnchorType.TopCenter:
                SetAnchor(CameraViewportHandler.Instance.TopCenter);
                break;
            case AnchorType.TopRight:
                SetAnchor(CameraViewportHandler.Instance.TopRight);
                break;
        }
    }

    void SetAnchor(Vector3 anchor)
    {
        Vector3 newPos = anchor + anchorOffset;
        if (!transform.position.Equals(newPos))
        {
            transform.position = newPos;
        }

        switch (orientation)
        {
            case Orientation.Width:
            {
                transform.localScale = new Vector3(CameraViewportHandler.Instance.Width, transform.localScale.y, transform.localScale.z);
                break;
            }
            case Orientation.Height:
            {
                transform.localScale = new Vector3(CameraViewportHandler.Instance.Height, transform.localScale.y, transform.localScale.z);
                break;
            }
        }
    }

#if UNITY_EDITOR
    // Update is called once per frame
    void Update()
    {
        
        if (_updateAnchorRoutine == null && executeInUpdate)
        {
            _updateAnchorRoutine = UpdateAnchorAsync();
            StartCoroutine(_updateAnchorRoutine);
        }
    }
#endif
}