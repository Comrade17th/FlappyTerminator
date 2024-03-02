using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    private Vector3 _direction;

    private void Update()
    {
        Vector3 position = transform.position + _direction;
        transform.position = Vector3.MoveTowards(transform.position,
            position,
            _speed * Time.deltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}
