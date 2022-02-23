using UnityEngine;

public class GrayScale : MonoBehaviour
{
    [SerializeField] private Shader _shader;

    private Material _material;

    private void Start()
    {
        _material = new Material(_shader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, _material);
    }
}
