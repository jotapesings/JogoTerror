using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour
{

    [SerializeField] ControlaAudio _audioPlayer;
    [SerializeField] AudioSource _soundMission;

    [SerializeField] Text _objectText;
    [SerializeField] float _duration;
    [SerializeField] float _durationEntreTexto;
    [SerializeField] string[] _textJogadorInicio;
    [SerializeField] string[] _textoDicaDoJogo;
    //[SerializeField] string[] _textJogadorGameplay;

    [SerializeField] int index;
    [SerializeField] int indexDica;


    [SerializeField] bool desativaDialogo;


    private void Awake()
    {
        desativaDialogo = PlayerPrefs.GetInt("desativa") == 1 ? true : false;
        _audioPlayer = FindObjectOfType<ControlaAudio>();
    }

    private void Start()
    {
        

        

        if (desativaDialogo == true)
        {
            StartCoroutine(TempoDialogoPlayerInicio());
            //StartCoroutine(TempoDicaDoJogo());
        }
    }


    private void Update()
    {
        



    }

    IEnumerator TempoDialogoPlayerInicio()
    {
        for (index = 0; index < _textJogadorInicio.Length; index++)
        {
            yield return new WaitForSeconds(_durationEntreTexto);
            _objectText.text = ""; // Limpa o texto
            _objectText.DOFade(1, 0.1f); // Garante que o texto esteja visível
            _audioPlayer._VozPlayer.GetComponent<AudioSource>().clip = _audioPlayer._BibliotecaVoz[index];
            _audioPlayer._VozPlayer.Play();
            yield return _objectText.DOText(_textJogadorInicio[index], _duration).WaitForCompletion(); // Anima o texto
            yield return new WaitForSeconds(1f); // Espera antes de desaparecer
            yield return _objectText.DOFade(0, 1f).WaitForCompletion(); // Faz o texto desaparecer
        }

        StartCoroutine(TempoDicaDoJogo());

    }

    IEnumerator TempoDicaDoJogo()
    {
        
        yield return new WaitForSeconds(_durationEntreTexto);
        _objectText.text = ""; // Limpa o texto
        _objectText.DOFade(1, 0.1f); // Garante que o texto esteja visível
        _soundMission.Play();
        yield return _objectText.text = _textoDicaDoJogo[indexDica];
        //yield return _objectText.DOText(_textoDicaDoJogo[indexDica], _duration).WaitForCompletion(); // Anima o texto
        yield return new WaitForSeconds(15f); // Espera antes de desaparecer
        yield return _objectText.DOFade(0, 1f).WaitForCompletion(); // Faz o texto desaparecer
        indexDica += 1;
    }

}
