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

    [SerializeField] LayerMask[] SelecionaLayer;

    [Header("Variavel de Itens")]
    //Variavel para pegar Itens
    [SerializeField] bool _encostouLantera;
    [SerializeField] bool _encostouFolha;

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
        PegaLanterna();
        PegaFolha();


    }


    void PegaLanterna()
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
            _folhaReal.SetActive(false);
            _folhaVirtual.SetActive(true);
        }

        if(value.performed && _encostouFolha == false)
        {
            _folhaVirtual.SetActive(false);
        }

    }
}
