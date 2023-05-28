using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    const int GAME_SCENE_INDEX = 1;

    public UnityEvent onPointsChange;

    public int points => _points;
    [SerializeField] private bool _startOnAwake;
    [SerializeField] private Transform _player;
    [Space]
    [SerializeField, Min(0)] private int _pointsXDelivery = 1;
    [Space]
    [SerializeField] private MissileLauncher _missileLauncher;
    [Header("Setup")]
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _gameoverPanel;

    private int _points;
    public static GameManager singleton;

    private void Awake()
    {
        if(singleton is null)
        {
            singleton = this;
        }
        _player?.GetComponent<Drone>().onDestroyed.AddListener(OnPLayerDestroyed);
    }

    private void Start()
    {
        if (!_startOnAwake) return;

        _gameoverPanel.SetActive(false);

        CrateDeliverySystem.singleton.onCreateDelivered.AddListener(OnCreateDelivered);
        CrateDeliverySystem.singleton.DispatchNewCrate();

        _missileLauncher.StartLauncher();
    }


    public void ReloadScene()
    {
        SceneManager.LoadScene(GAME_SCENE_INDEX);
    }

    private void GameOver()
    {
        DestroyAllMissiles();
        _missileLauncher.StopLauncher();
        _gamePanel.SetActive(false);
        _gameoverPanel.SetActive(true);
    }

    private void DestroyAllMissiles()
    {
        foreach (Missile missile in GameObject.FindObjectsOfType<Missile>())
        {
            Destroy(missile.gameObject);
        }
    }


    private void OnCreateDelivered()
    {
        _points += _pointsXDelivery;
        onPointsChange.Invoke();
        _missileLauncher.ResetLauncher();
        DestroyAllMissiles();
    }
    private void OnPLayerDestroyed()
    {
        GameOver();
    }
}
