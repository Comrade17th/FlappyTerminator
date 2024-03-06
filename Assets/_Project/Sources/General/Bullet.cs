using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Collider2D))]
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

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            Destroy(gameObject);
        }
    }
}
