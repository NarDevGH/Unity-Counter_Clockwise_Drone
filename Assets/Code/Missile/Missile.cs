using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIDestinationSetter))]
public class Missile : MonoBehaviour
{
    [SerializeField] private float _triggerDistance;
    [SerializeField,Min(0)] private float _smokeIntervals;
    [Header("Setup")]
    [SerializeField] private GameObject _smoke;
    [SerializeField] private GameObject _explosion;

    private Transform _target;
    public Transform Target => _target;

    private AIDestinationSetter _destinationSetter;
    private AILerp _ai;

    private List<Vector3> _pathBuffer = new List<Vector3>();

    private void Awake()
    {
        _destinationSetter = GetComponent<AIDestinationSetter>();
        _ai = GetComponent<AILerp>();

        if (_smoke) StartCoroutine(SmokeRoutine());
    }

    private void FixedUpdate()
    {
        if (TargetOnTriggerDistance())
        {
            Destroy(_target.gameObject);
        }
    }

    private bool TargetOnTriggerDistance()
    {
        return Vector3.Distance(transform.position, _target.position) < _triggerDistance;
    }

    private bool ReachingEndOfPath()
    {
        _ai.GetRemainingPath(_pathBuffer, out bool stale);
        if (_pathBuffer.Count > 2)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
        _destinationSetter.target = target;
    }

    private IEnumerator SmokeRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_smokeIntervals);
            Instantiate(_smoke,transform.position, Quaternion.identity);
        }
    }

    private void OnDestroy()
    {
        Instantiate(_explosion,transform.position, Quaternion.identity);
    }
}
