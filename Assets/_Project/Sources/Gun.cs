using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    
    [SerializeField] private float _shootCooldown = 0.5f;

    private Vector3 direction => transform.up;
    private bool _isAbleShoot = true;

    private WaitForSeconds _waitShoot;
    // private Coroutine _coroutine;
    private float _lastShootTime;
    
    private void Awake()
    {
        _waitShoot = new WaitForSeconds(_shootCooldown);

        Assert.IsNotNull(_bulletPrefab);
    }

    public void Shoot()
    {
        if (Time.time - _lastShootTime > _shootCooldown)
        {
            Bullet bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
            bullet.SetDirection(direction);
            
            // _coroutine = StartCoroutine(ShootCoolDown());
            _lastShootTime = Time.time;
        }
    }

    // private IEnumerator ShootCoolDown()
    // {
    //     _isAbleShoot = false;
    //     yield return _waitShoot;
    //     _isAbleShoot = true;
    // }
}
