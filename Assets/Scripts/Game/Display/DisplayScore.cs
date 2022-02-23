using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _scoreText;

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scoreText.text = "Score: " + score.ToString();
    }
}
