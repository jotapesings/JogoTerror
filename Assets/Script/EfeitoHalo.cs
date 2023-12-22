using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EfeitoHalo : MonoBehaviour
{
    public PostProcessVolume volume;
    private Bloom bloom;
    public float maxIntensity = 10f; // A intensidade máxima que você deseja alcançar
    public float speed = 1f; // A velocidade com que a intensidade muda

    void Start()
    {
        // Obtém o efeito Bloom do volume de pós-processamento
        volume.profile.TryGetSettings(out bloom);
    }

    void Update()
    {
        // Aumenta e diminui a intensidade do Bloom ao longo do tempo
        bloom.intensity.value = Mathf.PingPong(Time.time * speed, maxIntensity);
    }
}
