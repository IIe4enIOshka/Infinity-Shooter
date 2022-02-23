using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxWidth;
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Enemy>())
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            ApplyDamage(enemy);
            Destroy(gameObject);
        }

        if (collider.GetComponent<Clock>())
        {
            Clock clock = collider.GetComponent<Clock>();
            ApplyDamage(clock);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Move();

        if (transform.position.x > _maxWidth)
            Destroy(gameObject);
    }

    private void Move()
    {
        transform.position = new Vector2(transform.position.x + _speed * Time.deltaTime, transform.position.y);
    }

    public void ApplyDamage(Enemy enemy)
    {
        enemy.TakeDamage(_damage);
    }

    public void ApplyDamage(Clock clock)
    {
        clock.TakeDamage(_damage);
    }
}
