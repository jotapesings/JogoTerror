using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PegaItem : MonoBehaviour
{

    [SerializeField] ControlaPlayer _player;
    [SerializeField] GameObject _cinemachine;
    [SerializeField] Transform _referenciaCamera;
    [SerializeField] Transform _referenciaTela;

    [SerializeField] Transform _item;
    [SerializeField] LayerMask[] SelecionaLayer;
    [SerializeField] Rigidbody _itemGravidade;

    [SerializeField] Animator _animPortaQuarto;

    [Header("Variavel de Itens")]
    //Variavel para pegar Itens
    [SerializeField] public bool PegouItem;
    [SerializeField] public bool EntregouItem;
    [SerializeField] bool _encostouItem;

    //Variavel Quantidade de Itens
    [SerializeField] GameObject[] _peca;
    [SerializeField] public int _qtdItem;

    [Header("Variavel de Portas")]
    //Variavel para Abri Portas
    [SerializeField] bool _olhouPorta = false;
    [SerializeField] bool _Porta = false;

    [Header("Variavel da Maquina")]
    //Variavel para Acessar a Maquina do Tempo
    [SerializeField] bool _encostouEntrega = false;

    //[SerializeField] bool _ativouCamera = false;

    [Header("Raycast Objetos")]
    [SerializeField] Transform _objeto;

    // Update is called once per frame
    void Update()
    {
        PegadorDeItens();
        EntregaDeItens();


    }

    void PegadorDeItens()
    {
        RaycastHit PosicaoDoItem;


        if (Physics.Raycast(transform.position, transform.forward, out PosicaoDoItem, 3, SelecionaLayer[0]))
        {

            Debug.DrawLine(transform.position, PosicaoDoItem.point, Color.red);

            _encostouItem = true;
           // Debug.Log("Encostou no Bloco");

        }
        else
        {
            _encostouItem = false;
            //Debug.Log("Não está mais no Bloco");
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
