using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{


    private void Start()
    {

        Time.timeScale = 1;
    }

    public void  Iniciar()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        PlayerPrefs.SetInt("desativa", true ? 1 : 0);

        StartCoroutine(CarregarCena());
    }


    IEnumerator CarregarCena() //Carrega a Cena só quando o jogo carregar no PC da pessoa!
    {
        yield return new WaitForSeconds(.5f);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Tutorial");
        yield return null;
        while (!asyncOperation.isDone)
        {
            //this.barraProgresso.value = asyncOperation.progress;
            yield return null;
        }
    }


    public void Sair()
    {
        Application.Quit();
    }
}
