using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    
    [SerializeField] private int _scorePerDistance = 1;
    [SerializeField] private int _distacneToAddScore = 1;
    [SerializeField] private int _scorePerEnemy = 50;
    
    private int _score;
    private Vector3 _startPosition;
    private Vector3 _positionLastAdd;

    private bool _isScoringMovement = false;

    public int Score => _score;
    
    public event Action<int> Changed;

    private void Awake()
    {
        _startPosition = transform.position;
        _positionLastAdd = _startPosition;
    }

    private void OnEnable()
    {
        _inputHandler.FlyKeyPressed += EnableScoringMovement;
    }

    private void OnDisable()
    {
        _inputHandler.FlyKeyPressed -= EnableScoringMovement;
    }

    private void Update()
    {
        if (_isScoringMovement &&
            transform.position.x - _positionLastAdd.x >= _distacneToAddScore)
        {
            ScoreDistanceAdd();
            _positionLastAdd = transform.position;
        }    
    }
    
    public void Add(int value)
    {
        if(value > 0)
        _score += value;
        Changed?.Invoke(_score);
    }
    
    public void ScoreDistanceAdd()
    {
        Add(_scorePerDistance);
    }

    public void EnemyKilled()
    {
        Add(_scorePerEnemy);
    }
    
    public void Reset()
    {
        DisableScoringMovement();
        _score = 0;
        _positionLastAdd = _startPosition;
        Changed?.Invoke(_score);
    }

    private void EnableScoringMovement()
    {
        if (_isScoringMovement == false)
        {
            _positionLastAdd = transform.position;
            _isScoringMovement = true;    
        }
    }

    private void DisableScoringMovement()
    {
        _isScoringMovement = false;
    }
}
