using UnityEngine;

public class MissileLauncherTimer : MonoBehaviour
{
    const float START_WIDTH = 673;
    const float START_HEIGHT = 21;

    [SerializeField] private RectTransform _barRectTransform;

    private void Start()
    {
        _barRectTransform.sizeDelta = new Vector2(START_WIDTH,START_HEIGHT);
    }

    private void Update()
    {
        if (MissileLauncher.Singleton is not null)
        {
            float percentage = ((CurrentTime * 100) / MaxTime) / 100;
            float width = START_WIDTH * percentage;
            _barRectTransform.sizeDelta = new Vector2(width, START_HEIGHT);
        }
    }

    private float MaxTime => MissileLauncher.Singleton.LaunchMisileTime;
    private float CurrentTime => MissileLauncher.Singleton.LaunchMisileTimer;
}
