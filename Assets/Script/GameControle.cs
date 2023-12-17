using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;
using TMPro;
using Cinemachine;

public class GameControle : MonoBehaviour
{


    [SerializeField] Cinemachine.CinemachineBrain _camera;
    [SerializeField] ControlaPlayer _player;
    


    [SerializeField] GameObject _panel;
    [SerializeField] GameObject _panelMenu;

    MovimentoDino2 _ativador;

    public AudioSource _musicaAmbiente;

    public Rig _rigMao;

    public Lanterna _lanterna;
    public GameObject _objetoLanterna;


    // Start is called before the first frame update
    void Start()
    {
        
        _player = FindAnyObjectByType<ControlaPlayer>();
        _ativador = FindObjectOfType<MovimentoDino2>();
        _lanterna = FindObjectOfType<Lanterna>();
        _lanterna._desativaGlobal = true;

        StartCoroutine(AtivaGigantossauro());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && _player.vida >= 1)
        {
            Time.timeScale = 0;
            _panel.SetActive(false);
            _camera.enabled = false;
            _player._AtivaMovimento = false;
            _panelMenu.SetActive(true);
        }
        
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
