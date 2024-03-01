using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Collider2D))]

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    public event Action<IInteractable> CollisionDetected;


    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IInteractable interactable))
            CollisionDetected?.Invoke(interactable);
    }

    public interface IInteractable
    {
        
    }
}
