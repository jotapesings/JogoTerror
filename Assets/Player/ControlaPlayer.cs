using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class ControlaPlayer : MonoBehaviour
{

    [SerializeField] Transform _pernaE;
    [SerializeField] Transform _PernaD;

    [SerializeField] public bool _AtivaMovimento = true;
    [SerializeField] private bool _checkGround;
    [SerializeField] private bool _isJumping;

    [SerializeField] Vector3 _move;
    [SerializeField] Vector3 _velocity;
    [SerializeField] Vector3 _jumpPulo;

    [SerializeField] CharacterController _player;
    [SerializeField] Transform _MyCamera;

    [SerializeField] private AudioSource passosAudioSource;
    [SerializeField] private AudioSource pulandoAudioSource;

    [SerializeField] private AudioClip[] passosAudioClip;
    [SerializeField] private AudioClip[] pulandoAudioClip;

    [SerializeField] Animator _anim;

    [SerializeField] float _jumpForce;
    [SerializeField] float _gravity;
    [SerializeField] float _speed;

    [SerializeField] bool andou = false;



    void Start()
    {
        _player = GetComponent<CharacterController>();
        _MyCamera = Camera.main.transform;
    }

    void Update()
    {

        _checkGround = _player.isGrounded;

        MovimentoPlayer();
        GravidadePlayer();
        AnimaPlayer();



        _player.Move(_velocity * Time.deltaTime);

        
    }

    public void SetMove(InputAction.CallbackContext value)
    {
        if(value.performed && _AtivaMovimento == true)
        {
            _move = value.ReadValue<Vector3>();
        }
        

    }

    public void SetPulo(InputAction.CallbackContext value)
    {
        if (value.started && _checkGround)
        {
            _velocity.y = _jumpForce;
        }

    }

    void AnimaPlayer()
    {

        if (_move.y > 0.1f)
        {
            _anim.SetBool("andandoF", true);
        }

        if(_move.y < -0.1f)
        {
            _anim.SetBool("andandoT", true);
        }

        if (_move.y == 0)
        {
            _anim.SetBool("andandoF", false);
            _anim.SetBool("andandoT", false);
        }

        if(_move.x < -0.1f)
        {
            _anim.SetBool("andandoE", true);
        }

        if(_move.x > 0.1f)
        {
            _anim.SetBool("andandoD", true);
        }

        if(_move.x == 0f)
        {
            _anim.SetBool("andandoE", false);
            _anim.SetBool("andandoD", false);
        }
        
        if(_player.isGrounded == false)
        {
            _anim.SetLayerWeight(1, 1);
            _anim.SetBool("pulo", true);
        }

        if (_player.isGrounded == true)
        {
            _anim.SetLayerWeight(1, 0);
            _anim.SetBool("pulo", false);
        }

    }

    void MovimentoPlayer()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, _MyCamera.eulerAngles.y, transform.eulerAngles.z);

        //Leitura dos eixos do Input System

        float horizontalInput = _move.x;
        float verticalInput = _move.y;

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

    private void Pulando()
    {
        pulandoAudioSource.PlayOneShot(pulandoAudioClip[Random.Range(0, pulandoAudioClip.Length)]);
    }


}
