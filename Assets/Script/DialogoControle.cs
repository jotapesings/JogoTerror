using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class DialogoControle : MonoBehaviour
{

    [Header("Variavel para Pular a Cena")]
    public string proximaFase;

    [Header("Variaveis do Dialogo da História")]
    [SerializeField] GameObject _text;
    [SerializeField] TMP_Text _speechText;
    [SerializeField] string[] _caixaDialogo;
    [SerializeField] int index;
    [SerializeField] private float _tempoDialogo;

    //[Header("Variaveis do Dialogo do Objetivo")]
    //[SerializeField] GameObject _text2;
    //[SerializeField] TMP_Text _speechText2;
    //[SerializeField] string[] _caixaDialogo2;
    //[SerializeField] int index2;


    private void Start()
    {
        StartCoroutine(DialogoDaHistoria());
        
    }

    IEnumerator DialogoDaHistoria() //Caixa de Dialogo Automática
    {
        
        foreach (char letter in _caixaDialogo[index])
        {
            _speechText.text += letter;
            yield return new WaitForSeconds(_tempoDialogo);
            
        }

        yield return new WaitForSeconds(8f);
        _speechText.text = null; //Deixa o texto sem nada!
        
        if(index < 2)
        {
            index += 1;
            yield return DialogoDaHistoria();
        }

        StartCoroutine(CarregarCena());
        

    }


    IEnumerator CarregarCena()
    {
        yield return new WaitForSeconds(1f);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(proximaFase);
        yield return null;
        //while (!asyncOperation.isDone)
        //{
        //    this.barraProgresso.value = asyncOperation.progress;
        //    yield return null;
        //}
    }

    //IEnumerator DialogoLetrasObjetivo()
    //{
    //    yield return new WaitForSeconds(2f);
    //    _speechText2.text = _caixaDialogo2[index2];
    //    index2 += 1;
    //    yield return new WaitForSeconds(5f);
    //    _speechText2.text = null;
        
    //}

}
