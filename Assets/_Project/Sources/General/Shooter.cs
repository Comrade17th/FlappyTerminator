using UnityEngine;
using UnityEngine.Assertions;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Gun _gun;

    protected virtual void Awake()
    {
        Assert.IsNotNull(_gun);
    }

    protected void Shoot()
    {
        _gun.Shoot();
    }
}
