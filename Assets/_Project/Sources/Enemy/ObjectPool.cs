using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ObjectPool : MonoBehaviour
{
   [SerializeField] private Transform _container;
   [SerializeField] private Enemy _prefab;
   [SerializeField] private ScoreCounter _scoreCounter;
   
   private Queue<Enemy> _pool;

   public IEnumerable<Enemy> PooledObjects => _pool;

   private void Awake()
   {
      _pool = new Queue<Enemy>();
      Assert.IsNotNull(_scoreCounter);
      Assert.IsNotNull(_container);
      Assert.IsNotNull(_prefab);
   }

   public Enemy GetObject()
   {
      if (_pool.Count == 0)
      {
         Enemy enemy = Instantiate(_prefab);
         enemy.SetSpawner(this);
         enemy.SetCounter(_scoreCounter);
         enemy.transform.parent = _container;

         return enemy;
      }

      return _pool.Dequeue();
   }

   public void PutObject(Enemy enemy)
   {
      _pool.Enqueue(enemy);
      enemy.gameObject.SetActive(false);
   }

   public void Reset()
   {
      _pool.Clear();
   }
}
