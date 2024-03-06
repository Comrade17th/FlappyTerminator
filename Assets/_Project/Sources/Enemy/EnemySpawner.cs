using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemySpawner : MonoBehaviour
{
   [SerializeField] private float _delay;
   [SerializeField] private float _lowerBound;
   [SerializeField] private float _upperBound;
   [SerializeField] private ObjectPool _pool;

   private WaitForSeconds _waitSpawn;

   private void Awake()
   {
      _waitSpawn = new WaitForSeconds(_delay);
      Assert.IsNotNull(_pool);
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

      Enemy enemy = _pool.GetObject();
      enemy.transform.position = spawnPoint;
   }
   
}
