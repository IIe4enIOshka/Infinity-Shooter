using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisplayEnergy : MonoBehaviour
{
    [SerializeField] private Image _slider;
    [SerializeField] private Player _player;
    [SerializeField] private float _duration;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _player.EnergyChanged += OnEnergyChanged;
    }

    private void OnDisable()
    {
        _player.EnergyChanged -= OnEnergyChanged;
    }

    private void OnEnergyChanged(float energy)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Filling(_slider.fillAmount, energy));
    }

    private IEnumerator Filling(float startValue, float endValue)
    {
        float elapsed = 0;

        while (elapsed < _duration)
        {
            _slider.fillAmount = Mathf.Lerp(startValue, endValue, elapsed / _duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
