using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBar : MonoBehaviour
{

    private float _startWidth;
    private RectTransform _rectTransform;
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _startWidth = _rectTransform.sizeDelta.x;
    }

    private void Update()
    {
        if (MissileLauncher.Singleton is not null)
        {
            float percentage = ((CurrentTime * 100) / MaxTime) / 100;
            float width = _startWidth * percentage;
            _rectTransform.sizeDelta = new Vector2(width, _rectTransform.sizeDelta.y);
        }
    }

    private float MaxTime => MissileLauncher.Singleton.LaunchMisileTime;
    private float CurrentTime => MissileLauncher.Singleton.LaunchMisileTimer;
}
