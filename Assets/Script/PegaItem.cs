using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PegaItem : MonoBehaviour
{
    [SerializeField] GameObject _folhaVirtual;
    [SerializeField] GameObject _folhaReal;

    [SerializeField] GameControle _gameControle;
    [SerializeField] ControlaAudio _audioControle;
    [SerializeField] Lanterna _lanterna;

    [SerializeField] ControlaPlayer _player;
    [SerializeField] GameObject _cinemachine;
    [SerializeField] Transform _referenciaCamera;
    [SerializeField] Transform _referenciaTela;

    [SerializeField] Transform _item;
    [SerializeField] LayerMask[] SelecionaLayer;

    [Header("Variavel de Itens")]
    //Variavel para pegar Itens
    [SerializeField] public bool PegouItem;
    [SerializeField] public bool EntregouItem;
    [SerializeField] bool _encostouItem;
    [SerializeField] bool _encostouLantera;
    [SerializeField] bool _encostouFolha;

    //Variavel Quantidade de Itens
    [SerializeField] GameObject[] _peca;
    [SerializeField] public int _qtdItem;

    [Header("Variavel da Maquina")]
    //Variavel para Acessar a Maquina do Tempo
    [SerializeField] bool _encostouEntrega = false;

    //[SerializeField] bool _ativouCamera = false;

    [Header("Raycast Objetos")]
    [SerializeField] Transform _objeto;


    private void Start()
    {
        _lanterna = FindObjectOfType<Lanterna>();
        _gameControle = FindObjectOfType<GameControle>();
        _audioControle = FindObjectOfType<ControlaAudio>();
    }

    // Update is called once per frame
    void Update()
    {
        PegadorDeItens();
        EntregaDeItens();
        PegaLanterna();
        PegaFolha();


    }

    void PegadorDeItens() //Pega Itens
    {
        RaycastHit PosicaoDoItem;


        if (Physics.Raycast(transform.position, transform.forward, out PosicaoDoItem, 3, SelecionaLayer[0]))
        {

            Debug.DrawLine(transform.position, PosicaoDoItem.point, Color.red);

            _encostouItem = true;

        }
        else
        {
            _encostouItem = false;
        }
    }

    void PegaLanterna()
    {
        RaycastHit PosicaoDaLanterna;
        

        if (Physics.Raycast(transform.position, transform.forward, out PosicaoDaLanterna, 2, SelecionaLayer[2]))
        {

            Debug.DrawLine(transform.position, PosicaoDaLanterna.point, Color.red);

            _encostouLantera = true;

            //Essa linha faz com que apareça o texto Aperte "E";
            _gameControle._textoDosItens[0].gameObject.SetActive(true);
            

        }
        else
        {
            _encostouLantera = false;

            //Essa linha faz com que desapareça o texto Aperte "E";
            _gameControle._textoDosItens[0].gameObject.SetActive(false);
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

    void EntregaDeItens()
    {
        RaycastHit PosicaoDaEntrega;

        if (Physics.Raycast(transform.position, transform.forward, out PosicaoDaEntrega, 3, SelecionaLayer[1]))
        {

            Debug.DrawLine(transform.position, PosicaoDaEntrega.point, Color.blue);

            _encostouEntrega = true;

        }
        else
        {
            _encostouEntrega = false;
        }

    }


    /*
    void Portas()
    {
        RaycastHit PosicaoPorta;


        if (Physics.Raycast(transform.position, transform.forward, out PosicaoPorta, 1.5f, SelecionaLayer[1]))
        {

            Debug.DrawLine(transform.position, PosicaoPorta.point, Color.red);

            _olhouPorta = true;
        }
        else
        {
            _olhouPorta = false;
        }
    }

    void TelaCamera()
    {
        RaycastHit PosicaoTela;


        if (Physics.Raycast(transform.position, transform.forward, out PosicaoTela, 1.5f, SelecionaLayer[2]))
        {

            Debug.DrawLine(transform.position, PosicaoTela.point, Color.blue);

            //_olhouTela = true;

        }
        else
        {
            //_olhouTela = false;
        }
    }

    */

    public void SetObjeto(InputAction.CallbackContext value)
    {

        if(value.performed && _encostouItem == true) //Pega o Item na Primeira Fase
        {
            PegouItem = true; //Essa variavel é publica!
            _qtdItem += 1; //Essa variavel é publica!

        }

        if(value.performed && _encostouEntrega == true && _qtdItem >= 1) //Entrega o Item na Maquina do Tempo da Primeira Fase
        {
            EntregouItem = true;
            PegouItem = false;
            _qtdItem -= 1;
            _peca[0].SetActive(false);
        }   

        if(value.performed && _encostouEntrega == true)
        {

        }

        if(value.performed && _encostouLantera == true)
        {
            //Levanta a mão, ativa a Lanterna e sua Luz.
            _gameControle._rigMao.weight = 1;
            _lanterna.ativaL = true;
            _lanterna._lanterna.intensity = 3;


            //_audioControle.IniciarFala3(); //Essa linha ativa uma Fala;
            _gameControle._lanterna._desativaGlobal = false;
            _gameControle._objetoLanterna.SetActive(false);
            _gameControle._textoDosItens[0].gameObject.SetActive(false); ////Essa linha faz com que desapareça o texto Aperte "E"; 


        }

        if(value.performed && _encostouFolha == true)
        {
            _folhaReal.SetActive(false);
            _folhaVirtual.SetActive(true);
        }

        if(value.performed && _encostouFolha == false)
        {
            _folhaVirtual.SetActive(false);
        }

    }

    //private IEnumerator TimePortaAberta()
    //{
    //    _animPortaQuarto.Play("DoorSingleAbrir");
    //    yield return new WaitForSeconds(1f);
    //    _Porta = true;
    //}

    //private IEnumerator TimePortaFechada()
    //{
    //    _animPortaQuarto.Play("DoorSingleFechar");
    //    yield return new WaitForSeconds(1f);
    //    _Porta = false;
    //}
}
