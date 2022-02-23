using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Explode _templateExplode;
    [SerializeField] private Shoot _templateShoot;
    [SerializeField] private int _startHealth = 3;
    [SerializeField] private int _damage;
    [SerializeField] private Image _imageSlider;
    [SerializeField] private float _offsetX;

    private int _health;

    public Player Player { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            Player player = collision.GetComponent<Player>();
            ApplyDamage(player);
        }
    }

    private void Start()
    {
        _health = _startHealth;
    }

    public void Init(Player player)
    {
        Player = player;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _imageSlider.fillAmount = _health / (float)_startHealth;

        if (_health > 0)
            SpawnShoot();

        if (_health <= 0)
            Die();
    }

    private void SpawnShoot()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x - _offsetX, transform.position.y);
        Instantiate(_templateShoot, spawnPoint, Quaternion.identity);
    }

    private void SpawnExplode()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y);
        Instantiate(_templateExplode, spawnPoint, Quaternion.identity);
    }

    private void Die()
    {
        Player.KillEnemy(gameObject);
        SpawnExplode();
        Destroy(gameObject);
    }

    private void ApplyDamage(Player player)
    {
        player.TakeDamage(_damage);
    }
}
