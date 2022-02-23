using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using IJunior.TypedScenes;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _settings;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _resumeButton.onClick.AddListener(OnResumeButtonClick);
        _settingsButton.onClick.AddListener(OnSettingsButtonClick);
    }

    private void OnRestartButtonClick()
    {
        //SceneManager.LoadScene(0);
        Game.Load();
        Time.timeScale = 1f;
    }

    private void OnSettingsButtonClick()
    {
        _pause.SetActive(false);
        _settings.SetActive(true);
    }

    private void OnResumeButtonClick()
    {
        _pause.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnExitButtonClick()
    {
        _pause.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnPauseButtonClick()
    {
        _pause.SetActive(true);
        _settings.SetActive(false);
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);

        _resumeButton.onClick.RemoveListener(OnResumeButtonClick);
        _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
    }
}
