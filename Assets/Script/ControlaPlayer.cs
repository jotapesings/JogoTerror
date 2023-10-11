using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class ControlaPlayer : MonoBehaviour
{

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

    [SerializeField] float _jumpForce = 150;
    [SerializeField] float _gravity = -30;
    [SerializeField] float _speed = 5;


    [SerializeField] bool _isGrounded = false;


    void Start()
    {
        _player = GetComponent<CharacterController>();
        _MyCamera = Camera.main.transform;
    }

    void Update()
    {
        MovimentoPlayer();
        GravidadePlayer();
        AnimaPlayer();

        _player.Move(_velocity * Time.deltaTime);


    }

    public void SetMove(InputAction.CallbackContext value)
    {
        _move = value.ReadValue<Vector3>();
    }

    public void SetPulo(InputAction.CallbackContext value)
    {
        if (value.started && _player.isGrounded)
        {
            _velocity.y = _jumpForce;
        }

    }

    void AnimaPlayer()
    {

        if(_move.y > 0.1f)
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

        if(_player.isGrounded == true)
        {
            _anim.SetLayerWeight(1, 0);
            _anim.SetBool("pulo", false);
        }

    }

    void MovimentoPlayer()
    {

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, _MyCamera.eulerAngles.y, transform.eulerAngles.z);

        _velocity = new Vector3(_move.x * _speed, _velocity.y, _move.y * _speed);
        _velocity = transform.TransformDirection(_velocity);



    }

    void GravidadePlayer()
    {

        // Verifica se o personagem não está no chão.
        if (!_player.isGrounded)
        {
            // Aplica a gravidade à componente Y da velocidade.
            _velocity.y += _gravity * Time.deltaTime;
        }

    }



    private void Passos()
    {
        if(_player.isGrounded == true)
        {
            passosAudioSource.PlayOneShot(passosAudioClip[Random.Range(0, passosAudioClip.Length)]);
        }
    }

    private void Pulando()
    {
        pulandoAudioSource.PlayOneShot(pulandoAudioClip[Random.Range(0, pulandoAudioClip.Length)]);
    }
}
