using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PegaItem : MonoBehaviour
{

    [SerializeField] RandomOvo _ativaRandoOvos;


    [SerializeField] GameObject _ImageOvo;

    [SerializeField] GameObject _folhaVirtual;
    [SerializeField] GameObject _folhaReal;

    [SerializeField] GameControle _gameControle;
    [SerializeField] ControlaAudio _audioControle;
    [SerializeField] Lanterna _lanterna;

    [SerializeField] ControlaPlayer _player;

    [SerializeField] LayerMask[] SelecionaLayer;

    [SerializeField] RaycastHit PosicaoOvos;
    [SerializeField] RaycastHit PosicaoRelogio;

    [Header("Variavel de Itens")]
    //Variavel para pegar Itens
    [SerializeField] bool _encostouLantera;
    [SerializeField] bool _encostouFolha;
    [SerializeField] bool _encostouOvos;
    [SerializeField] bool _encostouRelogio;

    [Header("Raycast Objetos")]
    [SerializeField] Transform _objeto;
    
    public int qtd_ovos = 3;

    private void Start()
    {
        _ativaRandoOvos = FindObjectOfType<RandomOvo>();
        _lanterna = FindObjectOfType<Lanterna>();
        _gameControle = FindObjectOfType<GameControle>();
        _audioControle = FindObjectOfType<ControlaAudio>();
    }

    // Update is called once per frame
    void Update()
    {
        PegaLanterna();
        PegaFolha();
        PegaOvos();


        if(qtd_ovos == 0)
        {
            PegaRelogio();
        }

    }

    void PegaOvos() //Pega Ovos
    {

        if(Physics.Raycast(transform.position, transform.forward, out PosicaoOvos, 4))
        {

            Debug.DrawLine(transform.position, PosicaoRelogio.point, Color.blue);

            if (PosicaoOvos.transform.CompareTag("ovos"))
            {

                _encostouOvos = true;
            }
            else
            {
                _encostouOvos = false;
            }
        }


    }


    void PegaRelogio() //Toca Relogio
    {
        if (Physics.Raycast(transform.position, transform.forward, out PosicaoRelogio, 4))
        {

            Debug.DrawLine(transform.position, PosicaoRelogio.point, Color.blue);

            if (PosicaoRelogio.transform.CompareTag("relogio"))
            {
                _encostouRelogio = true;
            }
            else
            {
                _encostouRelogio = false;
            }
        }
    }


    void PegaLanterna() //Pega Lanterna
    {
        RaycastHit PosicaoDaLanterna;
        

        if (Physics.Raycast(transform.position, transform.forward, out PosicaoDaLanterna, 2, SelecionaLayer[2]))
        {

            Debug.DrawLine(transform.position, PosicaoDaLanterna.point, Color.red);

            _encostouLantera = true;

            

        }
        else
        {
            _encostouLantera = false;


        }
    }



    void PegaFolha() //Pega Folha
    {
        RaycastHit PosicaoFolha;


        if (Physics.Raycast(transform.position, transform.forward, out PosicaoFolha, 3, SelecionaLayer[3]))
        {

            Debug.DrawLine(transform.position, PosicaoFolha.point, Color.red);

            _encostouFolha = true;



        }
        else
        {
            _encostouFolha = false;
        }
    }







    public void SetObjeto(InputAction.CallbackContext value)
    {



        if(value.performed && _encostouLantera == true)
        {
            //Levanta a mão, ativa a Lanterna e sua Luz.
            _gameControle._rigMao.weight = 1;
            _lanterna.ativaL = true;
            _lanterna._lanterna.intensity = 3;


            //_audioControle.IniciarFala3(); //Essa linha ativa uma Fala;
            _gameControle._lanterna._desativaGlobal = false;
            _gameControle._objetoLanterna.SetActive(false);


        }

        if(value.performed && _encostouFolha == true)
        {
            _ImageOvo.SetActive(true);
            _folhaReal.SetActive(false);
            _folhaVirtual.SetActive(true);
            _ativaRandoOvos._ativaOvos = true;

        }
        if(value.performed && _encostouFolha == false)
        {
            _folhaVirtual.SetActive(false);
        }

        if(value.performed && _encostouOvos == true)
        {
            qtd_ovos -= 1;
            PosicaoOvos.transform.gameObject.SetActive(false);
            _encostouOvos = false;
        }

        if (value.canceled && _encostouOvos == false)
        {
            _encostouOvos = false;
        }

        if(value.performed && _encostouRelogio == true)
        {

            _player.StartCoroutine(_player.TempoRelogio());
            _encostouRelogio = false;


        }

    }
}
