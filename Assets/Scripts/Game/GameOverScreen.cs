using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using IJunior.TypedScenes;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private GameObject _fade;

    private CanvasGroup _gameOverGroup;

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();

        _gameOverGroup.alpha = 0;
    }

    private void OnEnable()
    {
        _player.Died += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnDied()
    {
        _camera.GetComponent<GrayScale>().enabled = true;
        _score.text = "Score: " + _player.Score;
        _gameOverGroup.alpha = 1;
        Time.timeScale = 0.2f;
    }

    private void OnRestartButtonClick()
    {
        Game.Load();
        Time.timeScale = 1f;
    }

    private void OnExitButtonClick()
    {
        _fade.GetComponent<Animator>().SetTrigger("fade");
        Time.timeScale = 1f;
    }
}
