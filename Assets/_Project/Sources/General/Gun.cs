using UnityEngine;
using UnityEngine.Assertions;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private float _shootCooldown = 0.5f;

    private Vector3 direction => transform.up;
    private bool _isAbleShoot = true;
    
    private float _lastShootTime;
    
    private void Awake()
    {
        Assert.IsNotNull(_bulletPrefab);
    }

    public void Shoot()
    {
        if (Time.time - _lastShootTime > _shootCooldown)
        {
            Bullet bullet = Instantiate(
                _bulletPrefab, 
                _bulletSpawnPoint.position,
                transform.rotation);
            bullet.SetDirection(direction);
            
            _lastShootTime = Time.time;
        }
    }
}
