using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissilesCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _textField;

    private int _counter = 0;

    private void Awake()
    {
    }

    private void Start()
    {
        MissileLauncher.Singleton.onMissileLaunched.AddListener(OnMissileLaunched);
        CrateDeliverySystem.singleton.onCreateDelivered.AddListener(OnCrateDelivered);
        UpdateTextField();
    }

    private void UpdateTextField()
    {
        _textField.text = $"{_counter}";
    }
    private void OnMissileLaunched()
    {
        _counter++;
        UpdateTextField();
    }
    private void OnCrateDelivered()
    {
        _counter = 0;
        UpdateTextField();
    }

}
