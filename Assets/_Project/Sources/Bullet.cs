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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(" bullet collides something");
        
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            Debug.Log(" bullet collides obstalce");
            Destroy(gameObject);
        }
            
    }
}
