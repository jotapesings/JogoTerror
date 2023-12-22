using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PegaItem : MonoBehaviour
{

    [SerializeField] GameObject _particulaRelogio;

    [SerializeField] AudioSource _itemCollectionSound;
    [SerializeField] AudioSource _soundPapel;

    [SerializeField] RelogioDialogo _ativaDialogoRelogio;

    [SerializeField] RandomOvo _ativaRandoOvos;
    [SerializeField] OvosDialogos _textDialogoDosOvos;

    [SerializeField] GameObject _ImageOvo;

    [SerializeField] GameObject _folhaReal;
    [SerializeField] PapelDialogO _textDialogoPapel;

    [SerializeField] GameControle _gameControle;
    [SerializeField] ControlaAudio _audioControle;

    [SerializeField] Lanterna _lanterna;
    [SerializeField] LanternaDialogo _textDialogoLanterna;

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
        _ativaDialogoRelogio = FindObjectOfType<RelogioDialogo>();
        _textDialogoDosOvos = FindObjectOfType<OvosDialogos>();
        _textDialogoPapel = FindObjectOfType<PapelDialogO>();
        _textDialogoLanterna = FindObjectOfType<LanternaDialogo>();
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

        if (Physics.Raycast(transform.position, transform.forward, out PosicaoOvos, 4))
        {

            Debug.DrawRay(transform.position, PosicaoOvos.point, Color.blue);

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

            Debug.DrawRay(transform.position, PosicaoRelogio.point, Color.blue);

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

            Debug.DrawRay(transform.position, PosicaoDaLanterna.point, Color.red);

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

            Debug.DrawRay(transform.position, PosicaoFolha.point, Color.red);

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
            _textDialogoLanterna._ativaDialogoLanterna = true;
            //Levanta a m�o, ativa a Lanterna e sua Luz.
            _gameControle._rigMao.weight = 1;
            _lanterna.ativaL = true;
            _lanterna._lanterna.intensity = 3;
            _itemCollectionSound.Play();
            //_audioControle.IniciarFala3(); //Essa linha ativa uma Fala;
            _gameControle._lanterna._desativaGlobal = false;
            _gameControle._objetoLanterna.SetActive(false);


        }

        if(value.performed && _encostouFolha == true)
        {
            _ImageOvo.SetActive(true);
            _soundPapel.Play();
            _textDialogoPapel._ativaDialogoPapel = true;
            _folhaReal.SetActive(false);
            _ativaRandoOvos._ativaOvos = true;

        }

        if(value.performed && _encostouOvos == true)
        {
            qtd_ovos -= 1;
            _itemCollectionSound.Play();
            _textDialogoDosOvos.continuar = true;
            _textDialogoDosOvos.StartCoroutine(_textDialogoDosOvos.DialogoOvo());
            if(qtd_ovos <= 0)
            {
                _particulaRelogio.SetActive(true);
                _textDialogoDosOvos.continuar = false;
                _textDialogoDosOvos.StartCoroutine(_textDialogoDosOvos.OutraCorroutina());
            }
            PosicaoOvos.transform.gameObject.SetActive(false);
            _encostouOvos = false;
        }

        if (value.canceled && _encostouOvos == false)
        {
            _encostouOvos = false;
        }

        if(value.performed && _encostouRelogio == true)
        {
            _ativaDialogoRelogio._ativaDialogoRelogio = true;
            _player.StartCoroutine(_player.TempoRelogio());
            PosicaoRelogio.transform.gameObject.SetActive(false);
            _encostouRelogio = false;
        }

        if(value.canceled && _encostouRelogio == false)
        {
            _encostouRelogio = false;
        }

    }
}
