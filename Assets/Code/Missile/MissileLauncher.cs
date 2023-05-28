using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissileLauncher : MonoBehaviour
{
    public float LaunchMisileTime => _launchMisileTime;
    public float LaunchMisileTimer => _launchMisileTimer;

    [HideInInspector]public UnityEvent onMissileLaunched;

    [SerializeField] private Transform _missileTarget;
    [SerializeField, Min(0)] private float _launchMisileTime;
    [Header("Setup")]
    [SerializeField] private GameObject _missile;
    [SerializeField] private Transform _launchOrigin;

    private float _launchMisileTimer;
    private Coroutine _timerCoroutine;

    public static MissileLauncher Singleton;
    private void Awake()
    {
        Singleton = this;
        
        _launchMisileTimer = _launchMisileTime;
    }

    public void StartLauncher()
    {
        if(_timerCoroutine is null)
        {
            _timerCoroutine = StartCoroutine(TimerRoutine());
        }
    }
    public void ResetLauncher()
    {
        ResetLaunchMisileTimer();
    }

    public void StopLauncher()
    {
        StopCoroutine(_timerCoroutine);
    }

    private void ResetLaunchMisileTimer()
    {
        _launchMisileTimer = _launchMisileTime;
    }

    private void OnLaunchMisileTimerOut()
    {
        GameObject missile = Instantiate(_missile, _launchOrigin.position, Quaternion.identity);
        missile.GetComponent<Missile>().SetTarget(_missileTarget);
        
        ResetLaunchMisileTimer();
    }

    private IEnumerator TimerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            _launchMisileTimer -= 1;
            if (_launchMisileTimer == 0)
            {
                OnLaunchMisileTimerOut();
                onMissileLaunched.Invoke();
            }
        }
    }
}
