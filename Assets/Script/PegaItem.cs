using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PegaItem : MonoBehaviour
{

    [SerializeField] Transform _item;
    [SerializeField] LayerMask[] SelecionaLayer;
    [SerializeField] Rigidbody _itemGravidade;

    [SerializeField] Animator _anim;

    [SerializeField] bool PegouItem;

    [SerializeField] bool _encostouItem;
    [SerializeField] bool _olhouPorta = false;
    [SerializeField] bool _Porta = false;
    

    [SerializeField] Transform _objeto;

    // Update is called once per frame
    void Update()
    {
        PegadorDeItens();
        Portas();

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
            Debug.Log("Encostou no Bloco");

        }
        else
        {
            _encostouItem = false;
            Debug.Log("Não está mais no Bloco");
        }
    }

    void Portas()
    {
        RaycastHit PosicaoPorta;


        if (Physics.Raycast(transform.position, transform.forward, out PosicaoPorta, 1.2f, SelecionaLayer[1]))
        {

            Debug.DrawLine(transform.position, PosicaoPorta.point, Color.red);

            _olhouPorta = true;
           

        }
        else
        {
            _olhouPorta = false;
        }
    }

    public void SetObjeto(InputAction.CallbackContext value)
    {

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
        _anim.Play("AbrePorta");
        yield return new WaitForSeconds(1f);
        _Porta = true;
    }

    private IEnumerator TimePortaFechada()
    {
        _anim.Play("FechaPorta");
        yield return new WaitForSeconds(1f);
        _Porta = false;
    }
}
