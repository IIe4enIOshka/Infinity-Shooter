using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Clock : MonoBehaviour
{
    [SerializeField] private Explode _templateExplode;
    [SerializeField] private Shoot _templateShoot;
    [SerializeField] private int _startHealth = 5;
    [SerializeField] private int _damage;
    [SerializeField] private Image _imageSlider;
    [SerializeField] private float _offsetX;
    [SerializeField] private Image _grayImage;

    public Player Player { get; private set; }
    private int _health;
    private Animator _animator;
    private bool _isDead;
    private bool _isRevival;

    public event UnityAction<bool> DeadChanged;

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
        _animator = GetComponent<Animator>();
    }

    public void Init(Player player)
    {
        Player = player;
    }

    public void TakeDamage(int damage)
    {
        if(_isDead == false)
        {
            _health -= damage;
            SetSliderValue(_health / (float)_startHealth);

            if (_health > 0)
                SpawnShoot();

            if (_health <= 0)
                Die();
        }

        if (_isDead == true && _isRevival == true)
        {
            SpawnShoot();
        }
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
        if(_isRevival == false)
        {
            _isDead = true;
            DeadChanged?.Invoke(_isDead);
            _isRevival = true;
            _animator.speed = 0;
            _grayImage.enabled = true;
            _grayImage.fillAmount = 1;
            StartCoroutine(FilledCoroutine());
        }
        else
        {
            Player.KillEnemy(gameObject);
            SpawnExplode();
            Destroy(gameObject);
        }
    }

    private IEnumerator FilledCoroutine()
    {
        while (_grayImage.fillAmount > 0)
        {
            _grayImage.fillAmount -= 0.03f;
            yield return new WaitForSeconds(0.1f);
        }

        _isDead = false;
        DeadChanged?.Invoke(_isDead);
        _grayImage.enabled = false;
        _animator.speed = 1;
        _health = _startHealth;
        SetSliderValue(_health);
        StopCoroutine(FilledCoroutine());
    }

    private void SetSliderValue(float health)
    {
        _imageSlider.fillAmount = health;
    }

    private void ApplyDamage(Player player)
    {
        player.TakeDamage(_damage);
    }
}
