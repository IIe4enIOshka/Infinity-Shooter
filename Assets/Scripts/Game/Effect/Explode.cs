using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] private float _duration;
    private float _currentTime;

    private void Update()
    {
        if(_currentTime >= _duration)
        {
            Destroy(gameObject);
        }

        _currentTime += Time.deltaTime;
    }
}
