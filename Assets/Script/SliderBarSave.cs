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
    }

    private void Update()
    {
        PlayerPrefs.SetFloat("mouseSensibilidade", _sliderSensibilidadeMouse.value);
    }
}
