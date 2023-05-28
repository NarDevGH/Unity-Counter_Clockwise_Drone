using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    [SerializeField, Min(0)] private float _displayDistance = 13;
    [SerializeField] private GameObject _sprite;
    [SerializeField] private Transform _dispatcher;

    public Transform SetTarget { set { _target = value; } }
    private Transform _target;

    private void Start()
    {
        CrateDeliverySystem.singleton.onCreateDelivered.AddListener(OnCrateDelivered);
        CrateDeliverySystem.singleton.onCreatePickedUp.AddListener(OnCratePickedUp);
        _target = _dispatcher;
    }

    private void Update()
    {
        if (_target is null) return;

        if (Vector3.Distance(transform.position, _target.position) < _displayDistance)
        {
            _sprite.SetActive(false);
        }
        else
        {
            _sprite.SetActive(true);

            // Rotate towards _target.
            Vector3 dir = transform.position - _target.position;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, -dir);
        }
    }

    private void OnCrateDelivered()
    {
        _target = _dispatcher;
    }

    private void OnCratePickedUp()
    {
        _target = CrateDeliverySystem.singleton.DeliverySpot.transform;
    }
}
