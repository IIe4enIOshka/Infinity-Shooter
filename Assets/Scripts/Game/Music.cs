using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _mainTheme;
    [SerializeField] private Player _player;

    private void Start()
    {
        _mainTheme.Play();
    }

    private void OnEnable()
    {
        _player.Died += OnDied;
    }

    private void OnDied()
    {
        StartCoroutine(MusicCoroutine());
    }

    private IEnumerator MusicCoroutine()
    {
        while (_mainTheme.pitch > 0.3f)
        {
            _mainTheme.pitch -= 0.01f;
            yield return null;
        }
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
    }
}
