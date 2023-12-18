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




    private void Start()
    {
        PlayerPrefs.SetInt("desativa", true ? 1 : 0);

        StartCoroutine(DialogoDaHistoria());
        
    }

    private void Update()
    {
        
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

    }

    public void avancaCenaHistoria()
    {
        StartCoroutine(CarregarCena());
    }

    IEnumerator CarregarCena() //Carrega a Cena só quando o jogo carregar no PC da pessoa!
    {
        yield return new WaitForSeconds(1f);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(proximaFase);
        yield return null;
    }


}
