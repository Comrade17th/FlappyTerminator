using UnityEngine;
using UnityEngine.Assertions;

public class Shooter : MonoBehaviour
{
    [SerializeField] protected Gun Gun;

    protected virtual void Awake()
    {
        Assert.IsNotNull(Gun);
    }
}
