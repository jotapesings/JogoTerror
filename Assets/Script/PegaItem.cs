using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

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
    [SerializeField] bool PegouItem;
    [SerializeField] bool _encostouItem;

    [Header("Variavel de Portas")]
    //Variavel para Abri Portas
    [SerializeField] bool _olhouPorta = false;
    [SerializeField] bool _Porta = false;

    [Header("Variavel de Tela")]
    //Variavel para Acessar a TV
    [SerializeField] bool _olhouTela = false;
    [SerializeField] bool _ativouCamera = false;

    [Header("Raycast Objetos")]
    [SerializeField] Transform _objeto;

    // Update is called once per frame
    void Update()
    {
        PegadorDeItens();
        Portas();
        TelaCamera();

        if (PegouItem == true)
        {
            _item.transform.position = _objeto.transform.position;
        }
        

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

            _olhouTela = true;

        }
        else
        {
            _olhouTela = false;
        }
    }

    public void SetObjeto(InputAction.CallbackContext value)
    {

        if(value.started && _olhouTela == true && _ativouCamera == false)
        {
            _cinemachine.SetActive(false);
            _player._AtivaMovimento = false;
            _referenciaCamera.transform.position = new Vector3(10.6f, 2.1f, -1.76f);
            _referenciaCamera.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            _ativouCamera = true;
        }
        
        else if (value.started && _olhouTela == true && _ativouCamera ==  true)
        {
            _cinemachine.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _player._AtivaMovimento = true;
            _ativouCamera = false;
        }


        if(value.started && _olhouPorta == true && _Porta == false)
        {

            StartCoroutine(TimePortaAberta());
           

        }

        if(value.started && _olhouPorta == true && _Porta == true)
        {

            StartCoroutine(TimePortaFechada());

        }


        if(value.started && _encostouItem == true)
        {
            PegouItem = true;
            _itemGravidade.useGravity = false;
        }

        if(value.started && _encostouItem == false)
        {
            PegouItem = false;
            _itemGravidade.useGravity = true;

        }
    }

    private IEnumerator TimePortaAberta()
    {
        _animPortaQuarto.Play("DoorSingleAbrir");
        yield return new WaitForSeconds(1f);
        _Porta = true;
    }

    private IEnumerator TimePortaFechada()
    {
        _animPortaQuarto.Play("DoorSingleFechar");
        yield return new WaitForSeconds(1f);
        _Porta = false;
    }
}
