using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpawnBullet))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private Hit _templateHit;
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private int _maxEnergy = 10;
    [SerializeField] private int _damageInvincibleMode = 3;
    [SerializeField] private Vector3 _sizeNormalMode = new Vector3(4.17f, 3.61f);
    [SerializeField] private Vector3 _offsetNormalMode = new Vector3(0, -0.72f);
    [SerializeField] private Vector3 _sizeInvincibleMode = new Vector3(7, 6);
    [SerializeField] private Vector3 _offsetInvincibleMode = new Vector3(-1, -0.9f);
    [SerializeField] private AudioSource _punch;
    [SerializeField] private AudioSource _invincible;

    private Animator _animator;
    private SpawnBullet _spawner;
    private PlayerMover _playerMover;
    private BoxCollider2D _boxCollider;
    private bool _isInvincibleMode = false;
    private int _health;
    private float _energy = 0;

    public int Score { get; private set; }
    public event UnityAction<float> EnergyChanged;
    public event UnityAction<float> HealthChanged;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction Died;

    public float MaxEnergy => _maxEnergy;

    private void Start()
    {
        Score = 0;
        _health = _maxHealth;
        _animator = GetComponent<Animator>();
        _spawner = GetComponent<SpawnBullet>();
        _playerMover = GetComponent<PlayerMover>();
        _boxCollider = GetComponent<BoxCollider2D>();
        HealthChanged?.Invoke(_health);
        ScoreChanged?.Invoke(Score);
        EnergyChanged?.Invoke(_energy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isInvincibleMode == true)
        {
            if (collision.GetComponent<Enemy>())
            {
                Enemy enemy = collision.GetComponent<Enemy>();
                ApplyDamage(enemy);
            }

            if (collision.GetComponent<Clock>())
            {
                Clock clock = collision.GetComponent<Clock>();
                ApplyDamage(clock);
            }
        }
    }

    public void TakeLife(int health)
    {
        if (_health < _maxHealth)
        {
            _health += health;
            HealthChanged?.Invoke((float) _health / _maxHealth);
        }
    }

    public void TakeEnergy(int energy)
    {
        if (_energy < _maxEnergy)
        {
            _energy += energy;
            EnergyChanged?.Invoke(_energy / _maxEnergy);
        }
    }

    private void ApplyDamage(Enemy enemy)
    {
        enemy.TakeDamage(_damageInvincibleMode);
    }

    private void ApplyDamage(Clock clock)
    {
        clock.TakeDamage(_damageInvincibleMode);
    }

    public void TakeDamage(int damage)
    {
        if (_isInvincibleMode == false)
        {
            _health -= damage;
            HealthChanged?.Invoke((float)_health / _maxHealth);
            SpawnHit();
            _punch.Play();
        }

        if (_health <= 0)
            Die();
    }

    public void KillEnemy(GameObject enemy)
    {
        if (enemy.GetComponent<Spike>())
        {
            AddScore(2);// цифры убрать
            AddEnergy(2);
        }

        if (enemy.GetComponent<BlueMonster>())
        {
            AddScore(1);
            AddEnergy(1);
        }

        if (enemy.GetComponent<Clock>())
        {
            AddScore(4);
            AddEnergy(4);
        }
    }

    public void AddEnergy(int energy)
    {
        if (_energy <= _maxEnergy && _isInvincibleMode == false)
            _energy += energy;

        if (_energy > _maxEnergy)
            _energy = _maxEnergy;

        EnergyChanged?.Invoke(_energy / _maxEnergy);
    }

    public void AddScore(int score)
    {
        Score+= score;
        ScoreChanged?.Invoke(Score);
    }

    private void SpawnHit()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y);
        Instantiate(_templateHit, spawnPoint, Quaternion.identity);
    }

    public void StartInvincibleMode()
    {
        if (_energy >= _maxEnergy)
        {
            _invincible.Play();
            _boxCollider.size = _sizeInvincibleMode;
            _boxCollider.offset = _offsetInvincibleMode;
            _playerMover.DoMove();
            _playerMover.DoScale();
            _isInvincibleMode = true;
            _animator.SetBool("IsInvincible", true);
            StartCoroutine(EnergyCoroutine());
        }
    }

    private IEnumerator EnergyCoroutine()
    {
        while (_energy > 0)
        {
            _energy -= 0.25f;
            EnergyChanged?.Invoke(_energy / _maxEnergy);
            yield return new WaitForSeconds(0.1f);
        }

        _boxCollider.size = _sizeNormalMode;
        _boxCollider.offset = _offsetNormalMode;
        _energy = 0;
        _isInvincibleMode = false;
        _animator.SetBool("IsInvincible", false);
        StopCoroutine(EnergyCoroutine());
    }

    public void SpawnBullet()
    {
        if (_isInvincibleMode == false && _health > 0)
            _spawner.Spawn();
    }

    public void Die()
    {
        Died?.Invoke();
        _animator.SetBool("OnDied", true); // убрать текст
    }
}
