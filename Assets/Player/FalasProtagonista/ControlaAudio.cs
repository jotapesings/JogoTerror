using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaAudio : MonoBehaviour
{

    [Header("Variavel do AudioAmbient")]
    [SerializeField] AudioSource _AmbientAudio;
    [Header("Variavel de Voz")]
    [SerializeField] AudioSource _VozPlayer;
    [SerializeField] AudioClip[] _BibliotecaVoz;


    [Header("Variavel Global da Fala")]
    [SerializeField] public bool _ativaFala;


    // Start is called before the first frame update
    void Start()
    {
        _AmbientAudio.Play();

        StartCoroutine(IniciaFala1());


    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator IniciaFala1()
    {
        yield return new WaitForSeconds(1f);
        _VozPlayer.PlayOneShot(_BibliotecaVoz[0]);
        _ativaFala = true;


    }

    public void IniciarFala3()
    {
        if(_ativaFala == true)
        {
            _VozPlayer.PlayOneShot(_BibliotecaVoz[1]);
        }
        
    }

}
