using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed = 5f;
    
    private Vector3 _direction;

    private void Update()
    {
        Vector3 position = transform.position + _direction;
        transform.position = Vector3.MoveTowards(transform.position,
            position,
            _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            Destroy(gameObject);
        }
        
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.ReturnToPool();
        }
    }
    
    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}
