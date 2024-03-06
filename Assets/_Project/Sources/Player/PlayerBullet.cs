using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.ReturnToPool();
        }
    }
}
