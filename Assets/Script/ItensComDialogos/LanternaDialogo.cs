using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LanternaDialogo : MonoBehaviour
{


    [SerializeField] AudioSource _vozInteragivel;
    [SerializeField] AudioClip[] _audioSelecionado;

    [SerializeField] Text _dialogoLanterna;
    [SerializeField] string[] _textoDialogoLanterna;

    bool continuar = true;
    int contador = 0;

    int index;

    public bool _ativaDialogoLanterna;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_ativaDialogoLanterna == true)
        {
            _ativaDialogoLanterna = false;
            StartCoroutine(DialogoLanterna());
        }
    }


    IEnumerator DialogoLanterna()
    {

        while (continuar)
        {
            _dialogoLanterna.text = ""; // Limpa o texto
            _dialogoLanterna.DOFade(1, 0.1f); // Garante que o texto esteja visível
            _dialogoLanterna.DOText(_textoDialogoLanterna[contador], 2f);
            _vozInteragivel.PlayOneShot(_audioSelecionado[contador]);
            yield return new WaitForSeconds(3f);
            yield return _dialogoLanterna.DOFade(0, 1f).WaitForCompletion(); // Faz o texto desaparecer

            contador++;

            if(contador >= 2)
            {
                continuar = false;
                
            }
        }


    }



}
