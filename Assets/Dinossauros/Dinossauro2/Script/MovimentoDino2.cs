using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimentoDino2 : MonoBehaviour
{




    [SerializeField] public bool ativaGigantossauro;

    [SerializeField] AudioSource _passosG;

    [SerializeField] Animator _anim;
    [SerializeField] NavMeshAgent _gigantossauro;
    [SerializeField] Transform _player;

    [SerializeField] public Transform _referenciaBoca;


    bool ativaAtaque =  true;

    // Start is called before the first frame update
    void Start()
    {
        ativaGigantossauro = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(ativaGigantossauro == true)
        {
            if (_gigantossauro.speed == 2.5f)
            {
                
                _anim.SetFloat("InputX", 0);
                _gigantossauro.destination = _player.transform.position;
            }

            if (_gigantossauro.speed == 0f)
            {
                StartCoroutine(TempoDaMordida());
            }
        }


       

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && ativaAtaque == true)
        {
            _gigantossauro.speed = 0f;
        }
    }


    public void PassosGigante()
    {
        _passosG.Play();
    }

    IEnumerator TempoDaMordida()
    {
        ativaAtaque = false;
        _anim.SetFloat("InputX", 1);
        _gigantossauro.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.5f);
        _gigantossauro.speed = 2.5f;
    }

}

