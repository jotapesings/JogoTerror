using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaAudio : MonoBehaviour
{
 

    [Header("Variavel do AudioAmbient")]
    [SerializeField] AudioSource _AmbientAudio;

    [Header("Variavel de Voz")]
    [SerializeField] public AudioSource _VozPlayer;
    [SerializeField] public AudioClip[] _BibliotecaVoz;




    [Header("Variavel Global da Fala")]
    [SerializeField] public bool _ativaFala;


    private void Awake()
    {
        _AmbientAudio.Play();
    }

    // Start is called before the first frame update
    void Start()
    {

        //StartCoroutine(IniciaFala1());



    }

    // Update is called once per frame
    void Update()
    {

    }

    //IEnumerator IniciaFala1()
    //{

    //    if(_pulaAudio < _BibliotecaVoz.Length)
    //    {
    //        yield return new WaitForSeconds(1f);
    //        _VozPlayer.PlayOneShot(_BibliotecaVoz[_pulaAudio]);
  
    //    }





    //}

    //public void IniciarFala3()
    //{
    //    if(_ativaFala == true)
    //    {
    //        _VozPlayer.PlayOneShot(_BibliotecaVoz[1]);
    //    }
        
    //}

}
