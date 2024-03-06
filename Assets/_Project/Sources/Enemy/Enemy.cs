using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using Object = UnityEngine.Object;

[RequireComponent(typeof(EnemyShooter))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyShooter _shooter;

    private ObjectPool _spawner;

    private void Awake()
    {
        Assert.IsNotNull(_shooter);
    }

    private void Start()
    {
        _shooter.LaunchShooting();
    }

    public void SetSpawner(ObjectPool spawner)
    {
        _spawner = spawner;
    }

    public void ReturnToPool()
    {
        Debug.Log($"Is Spawner null " + _spawner == null);
        _spawner.PutObject(this);
    }
}
