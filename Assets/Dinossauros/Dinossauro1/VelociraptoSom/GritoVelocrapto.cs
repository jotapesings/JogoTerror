using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GritoVelocrapto : MonoBehaviour
{

    [SerializeField] AudioSource _gritosVelo;
    [SerializeField] AudioClip[] _bibliotecaGritos;

    [SerializeField] Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GritoVelo()
    {
        _gritosVelo.PlayOneShot(_bibliotecaGritos[Random.Range(0, _bibliotecaGritos.Length)]);
    }

}
