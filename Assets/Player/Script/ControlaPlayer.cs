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


    [SerializeField] Transform _posicaoFinalJogador;

    [SerializeField] string sceneName;

    [SerializeField] MovimentoDino2 _referenciaBocaDino;

    [SerializeField] public bool paraTUDO = false;

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

    //Variavel para Animação Fluir
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


    [SerializeField] GameObject _morte;

    [SerializeField] AudioSource _danoAudio;
    [SerializeField] AudioSource _danoVoz;
    [SerializeField] AudioClip[] _bibliotecaDano;

    [SerializeField] public int vida;
    [SerializeField] Image _fechaImage;
    [SerializeField] Color[] _cor;

    [SerializeField] bool ativaSomDano;
    

    void Awake()
    {
        _referenciaBocaDino = FindObjectOfType<MovimentoDino2>();

        _player = GetComponent<CharacterController>();
        _MyCamera = Camera.main.transform;

        //StartCoroutine(AnimacaoInicial());


    }

    private void Start()
    {
        ativaSomDano = false;
    }

    void Update()
    {

        _checkGround = _player.isGrounded;

        MovimentoPlayer();
        GravidadePlayer();
        AnimaPlayer();
        VidaDoJogador();

        _player.Move(_velocity * Time.deltaTime);


        //Esse comando é só pra gente DEV. Poder destravar o jogador no inicio!
        if (Input.GetKey(KeyCode.Space))
        {
            _AtivaMovimento = true;
        }


    }



    public void VidaDoJogador()
    {


        if(vida <= 0)
        {
            _AtivaMovimento = false;
            _fechaImage.DOColor(_cor[0], 1f);

        }

        if(vida >= 3)
        {
            
            vida = 3;
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
        if(other.gameObject.CompareTag("velocrapto") && ativaSomDano == false)
        {
            StartCoroutine(TempoDeDano());
        }

        if(other.gameObject.CompareTag("gigantossauro"))
        {
            StartCoroutine(TempoDaMordidaGigantossauro());
        }

    }


    IEnumerator TempoDeDano()
    {
        vida -= 1;
        _morte.SetActive(true);
        _danoVoz.PlayOneShot((_bibliotecaDano[Random.Range(0, _bibliotecaDano.Length)]));
        _danoAudio.Play();
        ativaSomDano = true;
        yield return new WaitForSeconds(.5f);
        _morte.SetActive(false);
        ativaSomDano = false;



    }

    IEnumerator TempoDaMordidaGigantossauro()
    {

        _morte.SetActive(true);
        _danoAudio.Play();
        yield return new WaitForSeconds(1.5f);
        vida -= 3;



    }


    public IEnumerator TempoFimJogo()
    {
        _AtivaMovimento = false;
        yield return new WaitForSeconds(1f);
        _fechaImage.DOColor(_cor[0], 2f);
        yield return new WaitForSeconds(3f);
        transform.position = _posicaoFinalJogador.position;
        _fechaImage.DOColor(_cor[1], 2f);
        _AtivaMovimento = true;
        yield return new WaitForSeconds(1f);
    }


    public IEnumerator TempoRelogio()
    {
        _AtivaMovimento = false;
        yield return new WaitForSeconds(1f);
        _fechaImage.DOColor(_cor[0], 2f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("FimDoJogo");

    }

}
