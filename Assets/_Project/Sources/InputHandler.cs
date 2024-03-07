using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private KeyCode _shootKey = KeyCode.N;

    public event Action ShootKeyPressed;
    
    private void Update()
    {
        if (Input.GetKeyDown(_shootKey))
        {
            ShootKeyPressed?.Invoke();
        }
    }
}
