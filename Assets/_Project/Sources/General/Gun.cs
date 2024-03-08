using UnityEngine;
using UnityEngine.Assertions;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _emptyGameObject;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private float _shootCooldown = 0.5f;

    private Pool<Bullet> _pool;
    private Transform _bulletsContainer;
    private Vector3 direction => transform.up;
    private bool _isAbleShoot = true;
    
    private float _lastShootTime;
    
    private void Awake()
    {
        Assert.IsNotNull(_bulletPrefab);
        _bulletsContainer = Instantiate(_emptyGameObject, transform.position, transform.rotation);
        _pool = new Pool<Bullet>(_bulletPrefab, _bulletsContainer, transform,0);
    }

    public void Shoot()
    {
        if (Time.time - _lastShootTime > _shootCooldown)
        {
            Bullet bullet = _pool.Peek();
            bullet.transform.position = _bulletSpawnPoint.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetDirection(direction);
            
            _lastShootTime = Time.time;
        }
    }
}
