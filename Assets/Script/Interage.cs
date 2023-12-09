using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class Interage : MonoBehaviour
{



    [SerializeField] GameObject _textoButtonE;
    [SerializeField] bool _enconstou;
    [SerializeField] LayerMask[] SelecionaLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Interagindo();
    }


    void Interagindo()
    {
        RaycastHit PosicaoDaInteracao;

        if (Physics.Raycast(transform.position, transform.forward, out PosicaoDaInteracao, 3, SelecionaLayer[0]))
        {

            Debug.DrawLine(transform.position, PosicaoDaInteracao.point, Color.blue);

            _enconstou = true;

            _textoButtonE.SetActive(true);

        }
        else
        {
            _textoButtonE.SetActive(false);
        }

    }


    public void SetObjeto(InputAction.CallbackContext value)
    {

        if (value.performed && _enconstou == true) //Entrega o Item na Maquina do Tempo da Primeira Fase
        {
            Debug.Log("Vc vai viajar no tempo");
        }
        
        


    }

}
