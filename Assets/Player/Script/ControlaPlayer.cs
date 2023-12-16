using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaPlayer : MonoBehaviour
{

    [SerializeField] string sceneName;

    [SerializeField] MovimentoDino2 _referenciaBocaDino;

    [SerializeField] public bool paraTUDO = false;

    [SerializeField] Image _morteImg;
    [SerializeField] Color[] _cor;

    [SerializeField] Transform _pernaE;
    [SerializeField] Transform _PernaD;

    [SerializeField] public bool _AtivaMovimento;
    [SerializeField] private bool _checkGround;
    [SerializeField] private bool _isJumping;
    [SerializeField] private bool _ativaCorrida;
    [SerializeField] private bool _animaInicial;

    [SerializeField] Vector3 _move;
    [SerializeField] Vector3 _velocity;
    [SerializeField] Vector3 _jumpPulo;

    [SerializeField] CharacterController _player;
    [SerializeField] Transform _MyCamera;
    [SerializeField] Transform _refecenciaCamera;

    [SerializeField] private AudioSource passosAudioSource;
    [SerializeField] private AudioSource pulandoAudioSource;

    [SerializeField] private AudioClip[] passosAudioClip;
    [SerializeField] private AudioClip[] pulandoAudioClip;
    

    [SerializeField] Animator _anim;

    //Variavel para Anima��o Fluir
    private int InputXHash = Animator.StringToHash("InputX");
    private int InputYHash = Animator.StringToHash("InputY");
    private float smoothInputX;
    private float smoothInputY;
    private float velocityX;
    private float velocityY;

    [SerializeField] float _jumpForce;
    [SerializeField] float _gravity;
    [SerializeField] float _speed;
    [SerializeField] float _corrida;


    [SerializeField] int vida;

    [SerializeField] bool _gigantossauroMATAR;
    [SerializeField] bool _velociraptoATACA =  true;

    void Awake()
    {
        _velociraptoATACA = true;
        _referenciaBocaDino = FindObjectOfType<MovimentoDino2>();

        _player = GetComponent<CharacterController>();
        _MyCamera = Camera.main.transform;

        StartCoroutine(AnimacaoInicial());


    }

    void Update()
    {

        _checkGround = _player.isGrounded;

        MovimentoPlayer();
        GravidadePlayer();
        AnimaPlayer();
        VidaDoJogador();

        _player.Move(_velocity * Time.deltaTime);


        //Esse comando � s� pra gente DEV. Poder destravar o jogador no inicio!
        if (Input.GetKey(KeyCode.Space))
        {
            _AtivaMovimento = true;
        }




    }


    public void VidaDoJogador()
    {
        if(vida < 0 && _gigantossauroMATAR == true)
        {
            
            transform.DOMove(_referenciaBocaDino._referenciaBoca.position, .5f);
            DOTween.Kill(transform);
            
        }

        if(vida >= 4)
        {
            
            vida = 4;
        }

        

    }

    public void SetMove(InputAction.CallbackContext context)
    {
        if (_AtivaMovimento == true)
        {
            _move = context.ReadValue<Vector3>();
        }

                  

    }


    public void SetCorrida(InputAction.CallbackContext context)
    {
        if(context.performed && _ativaCorrida == true)
        {
            _speed = _corrida;
            _anim.SetBool("Corrida", true);

        }

        if(context.canceled )
        {
            _speed = 2f;
            _anim.SetBool("Corrida", false);

        }

    }


    public void SetAgachar(InputAction.CallbackContext context)
    {
        if(context.performed && _checkGround)
        {
            _ativaCorrida = false;
            _anim.SetBool("Troca", true);
            
        }

        if(context.canceled && _checkGround)
        {
            _ativaCorrida = true;
            _anim.SetBool("Troca", false);
        }
    }

    void AnimaPlayer()
    {
        smoothInputX = Mathf.SmoothDamp(smoothInputX, _move.x, ref velocityX, 0.1f);
        smoothInputY = Mathf.SmoothDamp(smoothInputY, _move.y, ref velocityY, 0.1f);
        _anim.SetFloat(InputXHash, smoothInputX);
        _anim.SetFloat(InputYHash, smoothInputY);
    }

    void MovimentoPlayer()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, _MyCamera.eulerAngles.y, transform.eulerAngles.z);

        //Leitura dos eixos do Input System

        _velocity = new Vector3(_move.x * _speed, _velocity.y, _move.y * _speed);
        _velocity = transform.TransformDirection(_velocity);

    }


    void GravidadePlayer()
    {

        if (_checkGround == true && _isJumping == true)
        {
            _velocity.y = 0f;
        }

        if(_checkGround == false && _isJumping == false)
        {
            _velocity.y += _gravity * Time.deltaTime;
        }

    }


    private void Passos()
    {
        if(_checkGround == true)
        {
            passosAudioSource.PlayOneShot(passosAudioClip[Random.Range(0, passosAudioClip.Length)]);
        }
    }


    IEnumerator AnimacaoInicial()
    {
        _AtivaMovimento = false;
        yield return new WaitForSeconds(12f);
        _AtivaMovimento = true;
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("velocrapto") && _velociraptoATACA == true)
        {
            StartCoroutine(TempoDeDano());
        }

        if(other.gameObject.CompareTag("gigantossauro"))
        {
            StartCoroutine(TempoDaMordidaGigantossauro(other.gameObject));
        }

    }


    IEnumerator TempoDeDano()
    {
        _velociraptoATACA = false;
        vida -= 3;
        _morteImg.DOColor(_cor[0], 0.2f);
        yield return new WaitForSeconds(1f);
        DOTween.Kill(this);
        StartCoroutine(CarregaGameOver());


    }

    IEnumerator TempoDaMordidaGigantossauro(GameObject value)
    {
        vida -= 3;
        _gigantossauroMATAR = true;
        _AtivaMovimento = false;
        _morteImg.DOColor(_cor[0], 0.5f);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(CarregaGameOver());



    }

    IEnumerator CarregaGameOver()
    {
        DOTween.Kill(transform);
        DOTween.KillAll();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }


}
