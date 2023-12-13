using UnityEngine;
using UnityEngine.AI;
using System;

public class MovimentoDino1 : MonoBehaviour
{
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
        float distanceToPlayer = Vector3.Distance(transform.position, _player.position);

        if (distanceToPlayer <= followDistance)
        {
            // Verifique se há um obstáculo entre o dinossauro e o jogador
            if (!Physics.Linecast(transform.position, _player.position, obstacleMask))
            {
                _agent.SetDestination(_player.transform.position);
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

        if (_ativaPatrulha == true && _agent.remainingDistance < 20f)
        {
            _agent.SetDestination(_pos[index].position);
            _agent.speed = 2.5f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("posicao"))
        {
            if (index < _pos.Length)
            {
                int aleatorio = random.Next(0, _pos.Length); //Randomiza a posicao o Dinossauro
                index += aleatorio;
            }

            if (index >= _pos.Length)
            {
                index = 0;
            }

        }
    }
}
