using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogoControle : MonoBehaviour
{

    

    [Header("Variaveis do Dialogo do Personagem")]
    [SerializeField] GameObject _text;
    [SerializeField] TMP_Text _speechText;
    [SerializeField] string[] _caixaDialogo;
    [SerializeField] int index;
    [SerializeField] private float _tempoDialogo;

    [Header("Variaveis do Dialogo do Objetivo")]
    [SerializeField] GameObject _text2;
    [SerializeField] TMP_Text _speechText2;
    [SerializeField] string[] _caixaDialogo2;
    [SerializeField] int index2;


    private void Start()
    {
        StartCoroutine(DialogoLetrasPersonagem());
        
    }


    private void Update()
    {
        //if(_ativadorDialogo == true)
        //{
        //    StartCoroutine(DialogoLetrasObjetivo());
        //}
    }

    IEnumerator DialogoLetrasPersonagem() //Caixa de Dialogo Automática
    {
        
        yield return new WaitForSeconds(2f);

        foreach (char letter in _caixaDialogo[index])
        {
            _speechText.text += letter;
            yield return new WaitForSeconds(_tempoDialogo);
            
        }

        yield return new WaitForSeconds(2f);
        _speechText.text = null; //Deixa o texto sem nada!
        
        if(index < 1)
        {
            index += 1;
            yield return DialogoLetrasPersonagem();
        }

        StartCoroutine(DialogoLetrasObjetivo());

    }


    IEnumerator DialogoLetrasObjetivo()
    {
        yield return new WaitForSeconds(2f);
        _speechText2.text = _caixaDialogo2[index2];
        index2 += 1;
        yield return new WaitForSeconds(5f);
        _speechText2.text = null;
        
    }

}
