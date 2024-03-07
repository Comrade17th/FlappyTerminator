using System;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private bool _isFirstJumped = false;

    private void Awake()
    {
        Assert.IsNotNull(_inputHandler);
        
        _startPosition = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void OnEnable()
    {
        _inputHandler.FlyKeyPressed += FlyUser;
    }

    private void OnDisable()
    {
        _inputHandler.FlyKeyPressed -= FlyUser;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if(_isFirstJumped == false &&
           transform.position.y <= 0)
            Fly();
    }

    private void Fly()
    {
        _rigidbody2D.velocity = new Vector2(_speed, _tapForce);
        transform.rotation = _maxRotation;
    }

    private void FlyUser()
    {
        _isFirstJumped = true;
        Fly();
    }

    public void Reset()
    {
        transform.position = _startPosition;
        _isFirstJumped = false;
    }
}
