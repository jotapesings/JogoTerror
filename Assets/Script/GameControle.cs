using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;
using TMPro;
using Cinemachine;
using UnityEngine.UI;

public class GameControle : MonoBehaviour
{

    [SerializeField] GameObject _mapa;

    [SerializeField] Cinemachine.CinemachineBrain _camera;
    [SerializeField] ControlaPlayer _player;

    [SerializeField] CinemachineVirtualCamera vcam;
    [SerializeField] Slider _barraSliderSensibilidadeMouse;

    [SerializeField] GameObject _panel;
    [SerializeField] GameObject _panelMenu;

    MovimentoDino2 _ativador;

    public AudioSource _musicaAmbiente;

    public Rig _rigMao;

    public Lanterna _lanterna;
    public GameObject _objetoLanterna;


    bool mapa_ativa;

    // Start is called before the first frame update
    void Start()
    {
        _barraSliderSensibilidadeMouse.value = PlayerPrefs.GetFloat("mouseSensibilidade");

        _player = FindAnyObjectByType<ControlaPlayer>();
        _ativador = FindObjectOfType<MovimentoDino2>();
        _lanterna = FindObjectOfType<Lanterna>();
        _lanterna._desativaGlobal = true;

        StartCoroutine(AtivaGigantossauro());
    }

    // Update is called once per frame
    void Update()
    {
        AjusteSensibilidadeMouse();

        if (Input.GetKeyDown(KeyCode.Escape) && _player.vida >= 1 && mapa_ativa == false)
        {
            Time.timeScale = 0;
            _panel.SetActive(false);
            _camera.enabled = false;
            _player._AtivaMovimento = false;
            _panelMenu.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            mapa_ativa = true;
            _mapa.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            mapa_ativa = false;
            _mapa.SetActive(false);
            
        }


    }


    public void AjusteSensibilidadeMouse()
    {
        // Obtenha a referência para o componente CinemachinePOV
        CinemachinePOV pov = vcam.GetCinemachineComponent<CinemachinePOV>();

        // Ajuste as propriedades de velocidade com base na sensibilidade do mouse


        pov.m_HorizontalAxis.m_MaxSpeed = _barraSliderSensibilidadeMouse.value;
        pov.m_VerticalAxis.m_MaxSpeed = _barraSliderSensibilidadeMouse.value;

        PlayerPrefs.SetFloat("mouseSensibilidade", _barraSliderSensibilidadeMouse.value);
        

    }

    IEnumerator AtivaGigantossauro()
    {
        yield return new WaitForSeconds(60f);
        _ativador.ativaGigantossauro = true;
    }

    public void DesabilidaPause()
    {
        Time.timeScale = 1;
        _player._AtivaMovimento = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


}
