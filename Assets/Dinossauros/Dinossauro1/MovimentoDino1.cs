using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimentoDino1 : MonoBehaviour
{

    NavMeshAgent _agent;

    //Variaveis para posicao do inimigo, patrulhamento
    [SerializeField] Transform[] _pos;
    [SerializeField] int index;

    //Variavel para seguir o Player;
    [SerializeField] Transform _player;
    [SerializeField] float _velocidadeDino1;

    bool _ativaPatrulha;


    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _ativaPatrulha = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(_ativaPatrulha == true)
        {
            _agent.SetDestination(_pos[index].transform.position);
            _agent.speed = 1.5f;
        }

        if(_ativaPatrulha == false)
        {
            _agent.SetDestination(_player.transform.position);
            _agent.speed = _velocidadeDino1;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("posicao"))
        {
            if(index < _pos.Length)
            {
                int aleatorio = Random.Range(0, _pos.Length); //Randomiza a posicao o Dinossauro
                index += aleatorio;
            }

            if (index >= _pos.Length)
            {
                index = 0;
            }

        }


        //if(other.gameObject.CompareTag("Player"))
        //{
        //    _ativaPatrulha = false;
        //}

    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if(other.gameObject.CompareTag("Player"))
    //    {
    //        _ativaPatrulha = true;
    //    }
    //}


}
