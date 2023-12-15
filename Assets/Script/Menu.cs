using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{

    [Header("Variavel para Pular a Cena")]
    public string proximaFase;

    public void  Iniciar()
    {
        StartCoroutine(CarregarCena());
    }


    IEnumerator CarregarCena() //Carrega a Cena só quando o jogo carregar no PC da pessoa!
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


    public void Sair()
    {
        Application.Quit();
    }
}
