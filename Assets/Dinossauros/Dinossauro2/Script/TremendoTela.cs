using UnityEngine;
using Cinemachine;

public class CameraShakeTrigger : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    private void Start()
    {
        if (virtualCamera != null)
        {
            virtualCameraNoise = virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
            virtualCameraNoise.m_AmplitudeGain = 0f; // Adicione isso
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            virtualCameraNoise.m_AmplitudeGain = 2f; // Ajuste a amplitude conforme necessário
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            virtualCameraNoise.m_AmplitudeGain = 0f;
        }
    }
}
