using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class ControlaPlayer : MonoBehaviour
{
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
    [SerializeField] float _rotationSpeed;

    [SerializeField] bool _isGrounded = false;

    Vector3 _move;
    Vector3 _velocity;

    void Start()
    {
        _player = GetComponent<CharacterController>();
        _MyCamera = Camera.main.transform;
    }

    void Update()
    {
        MovimentoPlayer();
        AplicaGravidade();
        AnimaPlayer();

        _player.Move(_velocity * Time.deltaTime);
    }

    public void SetMove(InputAction.CallbackContext value)
    {
        _move = value.ReadValue<Vector3>();
    }

    public void SetPulo(InputAction.CallbackContext value)
    {
        if (value.started && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpForce * -2.0f * _gravity * Time.deltaTime);

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
        
        if(_velocity.y > -1.9f && !_isGrounded)
        {
            _anim.SetLayerWeight(1, 1);
            _anim.SetBool("pulo", true);
        }

        if(_velocity.y <= -2f && _isGrounded)
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

    void AplicaGravidade()
    {
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f; // Quando o jogador está no chão, definimos uma velocidade vertical mínima.
        }
        else
        {
            _velocity.y += _gravity * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    private void Passos()
    {
        if(_isGrounded == true)
        {
            passosAudioSource.PlayOneShot(passosAudioClip[Random.Range(0, passosAudioClip.Length)]);
        }
    }

    private void Pulando()
    {
        pulandoAudioSource.PlayOneShot(pulandoAudioClip[Random.Range(0, pulandoAudioClip.Length)]);
    }
}
