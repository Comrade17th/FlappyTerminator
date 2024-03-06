using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        Console.WriteLine("Player Bullet collide smth");
        if (other.TryGetComponent(out Enemy enemy))
        {
            Console.WriteLine("Player Bullet collide enemy");
            enemy.ReturnToPool();
            Console.WriteLine("Player Bullet returnet enemy to pool");
        }
    }
}
