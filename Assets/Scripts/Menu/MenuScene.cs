using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;
using System.Collections;

public class MenuScene : MonoBehaviour
{
    [SerializeField] private Button _start;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _exit;
    [SerializeField] private Animator _fade;
    [SerializeField] private AudioSource _music;

    private void OnEnable()
    {
        _start.onClick.AddListener(OnButtonStartClick);
        _settings.onClick.AddListener(OnButtonSettingsClick);
        _exit.onClick.AddListener(OnButtonExitClick);
    }

    private void OnButtonExitClick()
    {
        Application.Quit();
    }

    private void OnButtonSettingsClick()
    {
        
    }

    private void OnButtonStartClick()
    {
        _fade.SetTrigger("fade");
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        while (_music.volume > 0)
        {
            _music.volume -= 0.005f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void OnFadeComplited()
    {
        Game.Load();
    }

    private void OnDisable()
    {
        _start.onClick.RemoveListener(OnButtonStartClick);
        _settings.onClick.RemoveListener(OnButtonSettingsClick);
        _exit.onClick.RemoveListener(OnButtonExitClick);
    }
}
