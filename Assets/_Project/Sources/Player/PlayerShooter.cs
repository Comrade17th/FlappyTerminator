using UnityEngine;
using UnityEngine.Assertions;

public class PlayerShooter : Shooter
{
    [SerializeField] private InputHandler _inputHandler;

    protected override void Awake()
    {
        base.Awake();
        Assert.IsNotNull(_inputHandler);   
    }
    
    private void OnEnable()
    {
        _inputHandler.ShootKeyPressed += Shoot;
    }
}
