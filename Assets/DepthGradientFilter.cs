using UnityEngine;
using Metavido.Decoder;

public sealed class DepthGradientFilter : MonoBehaviour
{
    [SerializeField] TextureDemuxer _demuxer = null;
    [SerializeField] Renderer _debugView = null;

    [field:SerializeField] public float Threshold { get; set; } = 0.2f;

    [SerializeField, HideInInspector] Shader _shader = null;

    public RenderTexture MaskTexture => _mask;

    RenderTexture _mask;
    Material _material;

    void Start()
    {
        _mask = new RenderTexture(960, 540, 0);
        _material = new Material(_shader);
        _debugView.material.mainTexture = _mask;
    }

    void OnDestroy()
    {
        Destroy(_mask);
        Destroy(_material);
    }

    void Update()
    {
        _material.SetFloat("_Threshold", Threshold);
        Graphics.Blit(_demuxer.DepthTexture, _mask, _material);
    }
}
