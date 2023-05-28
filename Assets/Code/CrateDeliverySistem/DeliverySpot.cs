using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Crate;
using UnityEngine.Events;

public class DeliverySpot : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Sprite[] _cratesImages;

    public UnityEvent onCreateDelivered = new UnityEvent();

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void DisplayCrateToDeliver(CrateType type)
    {
        switch (type)
        {
            case CrateType.Brown:
                _renderer.sprite = _cratesImages[0];
                break;
            case CrateType.Red:
                _renderer.sprite = _cratesImages[1];
                break;
            case CrateType.Blue:
                _renderer.sprite = _cratesImages[2];
                break;
            case CrateType.Green:
                _renderer.sprite = _cratesImages[3];
                break;
            case CrateType.Gray:
                _renderer.sprite = _cratesImages[4];
                break;
        }
    }

    private void OnCrateDelivered()
    {
        onCreateDelivered.Invoke();
        onCreateDelivered.RemoveAllListeners();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnCrateDelivered();
        }
    }
}
