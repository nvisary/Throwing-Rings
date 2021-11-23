using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class FormInputController : MonoBehaviour
{
    [SerializeField] private string _labelText = "Form Input";

    [SerializeField] private InputField.ContentType _contentType = InputField.ContentType.DecimalNumber;

    private Text _label;
    private InputField _inputField;

    private void Awake()
    {
        _label = GetComponentInChildren<Text>();
        _inputField = GetComponentInChildren<InputField>();
        Debug.Log(_inputField);
    }

    private void Start()
    {
        if (_label)
            _label.text = _labelText;

        if (_inputField)
            _inputField.contentType = _contentType;
    }

    private void OnValidate()
    {
        if (_label)
            _label.text = _labelText; 
        if (_inputField)
            _inputField.contentType = _contentType;
    }
}
