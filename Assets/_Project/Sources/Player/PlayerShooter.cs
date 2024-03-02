using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : Shooter
{
    [SerializeField] private KeyCode _shootKey = KeyCode.N;

    private void Update()
    {
        if (Input.GetKeyDown(_shootKey))
        {
            Gun.Shoot();
        }
    }
}
