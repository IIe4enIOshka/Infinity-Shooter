using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    [SerializeField] private Bullet _template;
    [SerializeField] private Transform _spawner;
    [SerializeField] private float _delay;
    [SerializeField] private AudioSource _audio;

    private Animator _animator;
    private float _lastTimeAttack;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _lastTimeAttack -= Time.deltaTime;
    }

    public void Spawn()
    {
        if(_lastTimeAttack <= 0)
        {
            _audio.Play();
            Instantiate(_template, _spawner.position, Quaternion.identity);
            _animator.SetTrigger("isShooting"); // убрать текст
            _lastTimeAttack = _delay;
        }
    }
}
