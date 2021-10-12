using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera _camera;
    //private BoxCollider _cameraBox;

    [SerializeField]
    private BoxCollider _topBoxCollider;
    
    [SerializeField]
    private BoxCollider _rightBoxCollider;
    
    [SerializeField]
    private BoxCollider _leftBoxCollider;
    void Start()
    {
        _camera = Camera.main;
        //_cameraBox = _camera != null ? _camera.GetComponent<BoxCollider>() : null;
        AspectRatioBoxChange();

    }

    // Update is called once per frame
    void Update()
    {
        //AspectRatioBoxChange();
    }

    private void AspectRatioBoxChange()
    {
        float height = 2f * _camera.orthographicSize;
        float width = height * _camera.aspect;
        //cameraBox.size = new Vector3(width, height, 1);
        Debug.Log(_camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _camera.transform.position.z)));
        // _topBoxCollider.size = new Vector3(width, 1, 1);
        // _topBoxCollider.transform.position = _camera.ScreenToWorldPoint(new Vector3(1, _camera.pixelHeight, _camera.nearClipPlane));
        //
        // _rightBoxCollider.size = new Vector3(1, height, 1);
        // _rightBoxCollider.transform.position = _camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, _camera.pixelHeight, _camera.nearClipPlane));
        //
        // _leftBoxCollider.size = new Vector3(1, height, 1);
        // _leftBoxCollider.transform.position =
        //     _camera.ScreenToWorldPoint(new Vector3(0, _camera.pixelHeight, _camera.nearClipPlane));
    }
}
