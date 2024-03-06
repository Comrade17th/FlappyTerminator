using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int _scorePerDistance = 1;
    [SerializeField] private int _distacneToAddScore = 1;
    [SerializeField] private int _scorePerEnemy = 50;
    
    private int _score;
    private Vector3 _startPosition;
    private Vector3 _positionLastAdd;

    public int Score => _score;
    
    public event Action<int> Changed;

    private void Awake()
    {
        _startPosition = transform.position;
        _positionLastAdd = _startPosition;
    }
    
    private void Update()
    {
        if (transform.position.x - _positionLastAdd.x >= _distacneToAddScore)
        {
            Add(_scorePerDistance);
            _positionLastAdd = transform.position;
        }    
    }
    
    public void Add()
    {
        _score++;
        Changed?.Invoke(_score);
    }
    
    public void Add(int value)
    {
        if(value > 0)
        _score += value;
        Changed?.Invoke(_score);
    }

    public void EnemyKilled()
    {
        Add(_scorePerEnemy);
    }
    
    public void Reset()
    {
        _score = 0;
        _positionLastAdd = _startPosition;
        Changed?.Invoke(_score);
    }
}
