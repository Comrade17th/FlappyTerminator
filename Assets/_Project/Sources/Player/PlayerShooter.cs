using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private KeyCode _shootKey = KeyCode.N;

    [SerializeField] private Gun _gun;

    private void Awake()
    {
        if(!_gun)
            throw new Exception("gun is not set");
    }

    private void Update()
    {
        if (Input.GetKeyDown(_shootKey))
        {
            _gun.Shoot();
        }
    }
}
