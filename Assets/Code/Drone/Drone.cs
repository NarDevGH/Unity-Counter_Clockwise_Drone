using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Drone : MonoBehaviour
{
    [SerializeField,Min(0)]private float _moveSpeed = 5f;
    [SerializeField,Min(0)]private float _rotationSpeed = 80f;
    [Header("Setup")]
    [SerializeField] private Animator animator;

    [HideInInspector] public UnityEvent onDestroyed;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical"); 
        float horizontalInput = Input.GetAxis("Horizontal");

        _rb.velocity = new Vector2(transform.up.x, transform.up.y) * verticalInput * _moveSpeed;
        transform.Rotate(Vector3.forward * -horizontalInput * _rotationSpeed * Time.deltaTime);

        if(horizontalInput != 0 || verticalInput != 0)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    private void OnDestroy()
    {
        onDestroyed.Invoke();
    }
}
