using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBarSave : MonoBehaviour
{
    [SerializeField] Slider _sliderSensibilidadeMouse;

    private void Start()
    {
        // Se a sensibilidade do mouse n�o foi modificada, defina-a como 300
        float defaultSensitivity = 300f;
        _sliderSensibilidadeMouse.value = PlayerPrefs.GetFloat("mouseSensibilidade", defaultSensitivity);

        if (_sliderSensibilidadeMouse.value != defaultSensitivity)
        {
            Debug.Log("Sensibilidade n�o foi modificada");
        }

        if (_sliderSensibilidadeMouse.value == defaultSensitivity)
        {
            Debug.Log("Sensibilidade � Igual a 300f");
        }

        // Adiciona um ouvinte de evento ao controle deslizante
        _sliderSensibilidadeMouse.onValueChanged.AddListener(delegate { SaveSensitivity(); });
    }

    // M�todo para salvar a sensibilidade do mouse
    void SaveSensitivity()
    {
        PlayerPrefs.SetFloat("mouseSensibilidade", _sliderSensibilidadeMouse.value);
    }
}
