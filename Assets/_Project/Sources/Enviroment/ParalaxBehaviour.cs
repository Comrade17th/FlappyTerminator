using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _followingTarget;
    [SerializeField, Range(0f, 1f)] private float _parallaxStenght = 0.1f;
    [SerializeField] private float _moveSpeed = 10f;

    private Vector3 _targetPreviousPosition;

    private void Awake()
    {
        if (_followingTarget == false)
            _followingTarget = Camera.main.transform;

        _targetPreviousPosition = _followingTarget.position;
    }

    private void Update()
    {
        Vector3 delta = _followingTarget.position - _targetPreviousPosition;

        _targetPreviousPosition = _followingTarget.position;
        transform.position = Vector3.MoveTowards(
            transform.position,
            transform.position - delta * _parallaxStenght,
            _moveSpeed * Time.deltaTime);
    }
}
