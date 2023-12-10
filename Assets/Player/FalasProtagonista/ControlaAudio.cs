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


    // Start is called before the first frame update
    void Start()
    {
        _VozPlayer.clip = _BibliotecaVoz[0];
        StartCoroutine(IniciaVozParaTest());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IniciaVozParaTest()
    {
        _AmbientAudio.Play();
        yield return new WaitForSeconds(1f);
        _VozPlayer.Play();
        
    }

}
