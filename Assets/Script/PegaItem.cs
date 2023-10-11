using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PegaItem : MonoBehaviour
{

    [SerializeField] Transform _item;
    [SerializeField] LayerMask SelecionaLayer;
    [SerializeField] Rigidbody _itemGravidade;

    [SerializeField] bool PegouItem;

    [SerializeField] bool _encostouItem;
    

    [SerializeField] Transform _objeto;

    // Update is called once per frame
    void Update()
    {
        RaycastHit PosicaoDoItem;

        
        if (Physics.Raycast(transform.position, transform.forward, out PosicaoDoItem, 3, SelecionaLayer))
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

        if (PegouItem == true)
        {
            _item.transform.position = _objeto.transform.position;
        }

        

    }


    public void SetObjeto(InputAction.CallbackContext value)
    {
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
}
