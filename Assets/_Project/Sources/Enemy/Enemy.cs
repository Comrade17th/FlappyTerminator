using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(EnemyShooter))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyShooter _shooter;

    private void Awake()
    {
        Assert.IsNotNull(_shooter);
    }

    private void Start()
    {
        _shooter.LaunchShooting();
    }
}
