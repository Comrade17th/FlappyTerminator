using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    
    [SerializeField] private float _shootCooldown = 0.5f;

    private Vector3 direction => transform.up;
    private bool _isAbleShoot = true;

    private WaitForSeconds _waitShoot;
    private Coroutine _coroutine;

    private void Awake()
    {
        _waitShoot = new WaitForSeconds(_shootCooldown);

        if (!_bulletPrefab)
            throw new Exception("Bullet not set");
    }

    public void Shoot()
    {
        if (_isAbleShoot)
        {
            Bullet bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
            bullet.SetDirection(direction);
            _coroutine = StartCoroutine(ShootCoolDown());    
        }
    }

    private IEnumerator ShootCoolDown()
    {
        _isAbleShoot = false;
        yield return _waitShoot;
        _isAbleShoot = true;
    }
}
