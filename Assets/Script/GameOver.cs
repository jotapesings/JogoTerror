using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{



    [SerializeField] ControlaPlayer _vidaJogador;
    [SerializeField] GameObject _panelGameOver;
    [SerializeField] GameObject _panel;




    private void Start()
    {

        PlayerPrefs.SetInt("desativa", false ? 1 : 0);

        _vidaJogador = FindObjectOfType<ControlaPlayer>();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }



    private void Update()
    {
        if(_vidaJogador.vida <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            StartCoroutine(TempoGameOver());
        }
    }

    public void reiniciar(string sceneName)
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void sair()
    {
        Application.Quit();
    }


    IEnumerator TempoGameOver()
    {
        yield return new WaitForSeconds(2f);
        _panel.SetActive(false);
        Time.timeScale = 0;
        _panelGameOver.SetActive(true);
    }

    //IEnumerator CarregaMenu() //Carrega a Cena só quando o jogo carregar no PC da pessoa!
    //{

    //    yield return new WaitForSeconds(1f);
    //    AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Menu");
    //    yield return null;
    //    while (!asyncOperation.isDone)
    //    {
    //       //this.barraProgresso.value = asyncOperation.progress;
    //       yield return null;
    //    }
    //}

}
