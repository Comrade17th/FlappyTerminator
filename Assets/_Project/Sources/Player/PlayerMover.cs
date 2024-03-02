using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private KeyCode _flyKey = KeyCode.Space;
    
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    // [SerializeField] private float _autoFlyCooldown = 1f;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private bool _isFirstJumped = false;
    // private WaitForSeconds _waitAutoFly;

    private void Awake()
    {
        // _waitAutoFly = new WaitForSeconds(_autoFlyCooldown);
        
        _startPosition = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    // private void Start()
    // {
    //     StartCoroutine(AutoFlying());
    // }

    private void Update()
    {
        if(_isFirstJumped == false &&
           transform.position.y <= 0)
             Fly();
        
        if (Input.GetKeyDown(_flyKey))
        {
            _isFirstJumped = true;
           Fly();
        }
        
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    // private void AutoFly()
    // {
    //     Fly();
    //     
    //     _lastFlyTime = Time.time;
    // }

    private void Fly()
    {
        _rigidbody2D.velocity = new Vector2(_speed, _tapForce);
        transform.rotation = _maxRotation;
    }

    // private IEnumerator AutoFlying()
    // {
    //     while(_isFirstJumped == false)
    //     {
    //         Fly();
    //         yield return _waitAutoFly;
    //     }
    // }

    public void Reset()
    {
        
    }
}
