using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using System;

public class MovimentoDino1 : MonoBehaviour
{


    [SerializeField] Animator _anim;
    NavMeshAgent _agent;
    private static readonly System.Random random = new System.Random();

    //Variaveis para posicao do inimigo, patrulhamento
    [SerializeField] Transform[] _pos;
    [SerializeField] int index;

    //Variavel para seguir o Player;
    [SerializeField] Transform _player;
    [SerializeField] float _velocidadeDino1;

    [SerializeField] float followDistance;
    [SerializeField] float stopFollowDistance;  // Distância para parar de seguir o jogador


    [SerializeField] LayerMask obstacleMask;  // Máscara para identificar obstáculos

    bool _ativaPatrulha;

    float currentSpeed = 0f;
    float smoothTime = 0.1f;
    float velocity = 0f;

    float tempoParado = 0f;  // Contador para o tempo que o dinossauro está parado
    float intervaloParada = 10f;  // O dinossauro vai parar a cada 5 segundos
    float duracaoParada = 2f;  // O dinossauro vai parar por 2 segundos


    [SerializeField] AudioSource _passos;

    // Start is called before the first frame update
    void Start()
    {

        _agent = GetComponent<NavMeshAgent>();
        index = random.Next(0, _pos.Length); //Randomiza a posicao o Dinossauro
        _agent.SetDestination(_pos[index].position);
        _ativaPatrulha = true;
    }

    // Update is called once per frame
    void Update()
    {
        float targetSpeed = _agent.speed;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref velocity, smoothTime);

        if (_agent.velocity == Vector3.zero)
        {
            _anim.SetFloat("InputX", 0);
        }
        else
        {
            _anim.SetFloat("InputX", currentSpeed);
        }


        float distanceToPlayer = Vector3.Distance(transform.position, _player.position);

        if (distanceToPlayer <= followDistance)
        {
            // Verifique se há um obstáculo entre o dinossauro e o jogador
            if (!Physics.Linecast(transform.position, _player.position, obstacleMask))
            {
                _agent.SetDestination(_player.position);
                _agent.speed = _velocidadeDino1;
                _ativaPatrulha = false;


            }
            else
            {
                _ativaPatrulha = true;
            }

        }
        else if (distanceToPlayer > stopFollowDistance)
        {
            _ativaPatrulha = true;
        }

        if (_ativaPatrulha && !_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
        {

            tempoParado += Time.deltaTime;

            if (tempoParado >= intervaloParada)
            {
                _agent.isStopped = true;  // Faz o dinossauro parar
                _agent.speed = 0f;  // Define a velocidade para 0 para ativar a animação de "parado"

                if (tempoParado >= intervaloParada + duracaoParada)
                {
                    _agent.isStopped = false;  // Faz o dinossauro começar a se mover novamente
                    tempoParado = 0f;  // Reinicia o contador

                    index = random.Next(0, _pos.Length); // Seleciona um ponto de patrulha aleatório
                    _agent.SetDestination(_pos[index].position);
                    _agent.speed = 2.5f;  // Define a velocidade de volta para 2.5 para ativar a animação de movimento
                }
            }
        }
    }


    public void DinoPassos()
    {
        _passos.Play();
    }

}
