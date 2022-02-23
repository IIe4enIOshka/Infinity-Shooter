using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    //[SerializeField] private Button _soundButton;
    //[SerializeField] private Button _musicButton;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _pause;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _beforeButton;


    private void OnEnable()
    {
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _beforeButton.onClick.AddListener(OnBeforeButtonClick);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _beforeButton.onClick.RemoveListener(OnBeforeButtonClick);
    }

    private void OnBeforeButtonClick()
    {
        _settings.SetActive(false);
        _pause.SetActive(true);
    }

    private void OnExitButtonClick()
    {
        _settings.SetActive(false);
        Time.timeScale = 1f;
    }
}
