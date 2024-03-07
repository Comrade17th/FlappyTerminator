using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private KeyCode _shootKey = KeyCode.N;
    [SerializeField] private KeyCode _flyKey = KeyCode.Space;

    public event Action ShootKeyPressed;
    public event Action FlyKeyPressed;
    
    private void Update()
    {
        if (Input.GetKeyDown(_shootKey))
            ShootKeyPressed?.Invoke();
        
        if(Input.GetKeyDown(_flyKey))
            FlyKeyPressed?.Invoke();
    }
}
