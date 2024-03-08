using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(EnemyShooter))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyShooter _shooter;

    private ObjectPool _spawner;
    private ScoreCounter _scoreCounter;

    private void Awake()
    {
        Assert.IsNotNull(_shooter);
    }

    private void Start()
    {
        _shooter.LaunchShooting();
    }

    // public void SetSpawner(ObjectPool spawner)
    // {
    //     _spawner = spawner;
    // }
    
    public void SetCounter(ScoreCounter scoreCounter)
    {
        _scoreCounter = scoreCounter;
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}
