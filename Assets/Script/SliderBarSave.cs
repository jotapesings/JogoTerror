using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBarSave : MonoBehaviour
{


    [SerializeField] Slider _sliderSensibilidadeMouse;



    private void Start()
    {
        _sliderSensibilidadeMouse.value = PlayerPrefs.GetFloat("mouseSensibilidade");


        if (_sliderSensibilidadeMouse.value != 300f)
        {
            Debug.Log("Sensibilidade n�o foi modificada");
            _sliderSensibilidadeMouse.value = PlayerPrefs.GetFloat("mouseSensibilidade");
        }
        
        if (_sliderSensibilidadeMouse.value == 300f)
        {
            Debug.Log("Sensibilidade � Igual a 300f");
            _sliderSensibilidadeMouse.value = 300f;
        }
    }

    private void Update()
    {
        PlayerPrefs.SetFloat("mouseSensibilidade", _sliderSensibilidadeMouse.value);
    }
}
