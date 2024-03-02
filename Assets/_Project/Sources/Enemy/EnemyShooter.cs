using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShooter : Shooter
{
    [SerializeField] private float _shootCooldown = 3f;

    private WaitForSeconds _waitShoot;
    private Coroutine _coroutine;

    protected override void Awake()
    {
        base.Awake();
        _waitShoot = new WaitForSeconds(_shootCooldown);
    }

    public void LaunchShooting()
    {
        _coroutine ??= StartCoroutine(Shooting());
    }
    
    private IEnumerator Shooting()
    {
        while (gameObject.activeSelf)
        {
            Gun.Shoot();
            yield return _waitShoot;    
        }
    }
}
