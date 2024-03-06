using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int _scorePerDistance = 1;
    [SerializeField] private int _distacneToAdd = 1;
    
    [SerializeField] private int _scorePerEnemy = 50;
    
    private int _score;
    private Vector3 _positionLastAdd;
    public event Action<int> Changed;

    private void Awake()
    {
        _positionLastAdd = transform.position;
    }
    
    private void Update()
    {
        if (transform.position.x - _positionLastAdd.x >= _distacneToAdd)
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
        Changed?.Invoke(_score);
    }
}
