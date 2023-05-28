using Crate;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrateDeliverySystem : MonoBehaviour
{
    [SerializeField] private Dispatcher _dispatcher;
    [SerializeField] private DeliverySpot[] _deliverySpots;

    public DeliverySpot DeliverySpot { get { return _deliverySpot; } }
    private DeliverySpot _deliverySpot;

    private CrateType _currentCrateType;

    [HideInInspector]public UnityEvent onCreateDelivered;
    [HideInInspector] public UnityEvent onCreatePickedUp;

    public static CrateDeliverySystem singleton;
    private void Awake()
    {
       singleton = this;
    }

    public void DispatchNewCrate()
    {
        _currentCrateType = CrateHelper.randomType();

        _dispatcher.Dispatch(_currentCrateType);
        _dispatcher.onCratePickedUp.AddListener(OnCratePickedUp);
        
    }
    private void OnCratePickedUp()
    {
        _deliverySpot = _deliverySpots[Random.Range(0, _deliverySpots.Length)];
        _deliverySpot.DisplayCrateToDeliver(_currentCrateType);
        _deliverySpot.gameObject.SetActive(true);
        _deliverySpot.onCreateDelivered.AddListener(OnCrateDelivered);
        onCreatePickedUp.Invoke();
    }

    private void OnCrateDelivered()
    {
        onCreateDelivered.Invoke();
        DispatchNewCrate();
    }

}
