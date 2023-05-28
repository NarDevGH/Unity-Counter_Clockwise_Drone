using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Crate;
using UnityEngine.Events;

public class Dispatcher : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _dispatcherRenderer;
    [SerializeField] private Sprite[] _cratesImages;

    [HideInInspector] public UnityEvent onCratePickedUp;

    public void Dispatch(CrateType crateType)
    {
        SetDispatcherSpriteToCrateType(crateType);
    }

    private void SetDispatcherSpriteToEmpty()
    {
        _dispatcherRenderer.sprite= _cratesImages[0];
    }
    private void SetDispatcherSpriteToCrateType(CrateType type)
    {
        // Change dispatcher sprite to the one for the crate selected.
        switch (type)
        {
            case CrateType.Brown:
                _dispatcherRenderer.sprite = _cratesImages[1];
                break;
            case CrateType.Red:
                _dispatcherRenderer.sprite = _cratesImages[2];
                break;
            case CrateType.Blue:
                _dispatcherRenderer.sprite = _cratesImages[3];
                break;
            case CrateType.Green:
                _dispatcherRenderer.sprite = _cratesImages[4];
                break;
            case CrateType.Gray:
                _dispatcherRenderer.sprite = _cratesImages[5];
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SetDispatcherSpriteToEmpty();
            onCratePickedUp.Invoke();
            onCratePickedUp.RemoveAllListeners();
        }
    }
}
