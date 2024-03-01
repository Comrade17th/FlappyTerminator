using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _followingTarget;
    [SerializeField, Range(0f, 1f)] private float _parallaxStenght = 0.1f;
    [SerializeField] private bool _disableVerticalParallax;

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

        if (_disableVerticalParallax)
            delta.y = 0;

        _targetPreviousPosition = _followingTarget.position;
        transform.position += delta * _parallaxStenght;
    }
}
