using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantidadePecas : MonoBehaviour
{

    [SerializeField] private GameObject[] _peca; //Aqui recebe o imgItemPeca. Essa variavel vai fazer com que ela apareça na tela quando receber o item.
    [SerializeField] PegaItem _quantidadePecas; //Essa variavel puxa outra variavel no Script "PegaItem", ela vai receber o item quando apertar o botão E do teclado.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_quantidadePecas.PegouItem == true)
        {
            _peca[0].SetActive(true);
        }
    }
}
