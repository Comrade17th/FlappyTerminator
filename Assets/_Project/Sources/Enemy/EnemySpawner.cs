using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemySpawner : MonoBehaviour
{
   [SerializeField] private Enemy _prefab;
   [SerializeField] private float _delay;
   [SerializeField] private float _lowerBound;
   [SerializeField] private float _upperBound;
    
   private Pool<Enemy> _pool;
   private WaitForSeconds _waitSpawn;

   private void Awake()
   {
      _pool = new Pool<Enemy>(_prefab, transform, 0);
      _waitSpawn = new WaitForSeconds(_delay);
   }

   private void Start()
   {
      StartCoroutine(SpawnEnemies());
   }

   private IEnumerator SpawnEnemies()
   {
      while (enabled)
      {
         Spawn();
         yield return _waitSpawn;
      }
   }

   private void Spawn()
   {
      float spawnPositionY = Random.Range(_upperBound, _lowerBound);
      Vector3 spawnPoint = new Vector3(
         transform.position.x,
         spawnPositionY,
         transform.position.z);

      Enemy enemy = _pool.Peek();
      enemy.transform.position = spawnPoint;
   }
   
}
