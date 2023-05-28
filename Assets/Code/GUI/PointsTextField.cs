using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsTextField : MonoBehaviour
{
    private TMP_Text _textField;

    private void Awake()
    {
        _textField = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        GameManager.singleton.onPointsChange.AddListener(OnPointsChange);
    }

    private void OnPointsChange()
    {
        _textField.text = $"Points: {GameManager.singleton.points}";
    }
}
