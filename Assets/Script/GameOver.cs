using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    [SerializeField] string[] cena;


    public void reiniciar()
    {
        StartCoroutine(CarregarCena());
    }

    public void menu()
    {
        SceneManager.LoadScene(cena[1]);
    }

    public void sair()
    {
        Application.Quit();
    }


    IEnumerator CarregarCena() //Carrega a Cena só quando o jogo carregar no PC da pessoa!
    {
        yield return new WaitForSeconds(1f);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(cena[0]);
        yield return null;
        //while (!asyncOperation.isDone)
        //{
        //    this.barraProgresso.value = asyncOperation.progress;
        //    yield return null;
        //}
    }

}
