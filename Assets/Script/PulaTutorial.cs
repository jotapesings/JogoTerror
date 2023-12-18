using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PulaTutorial : MonoBehaviour
{

    string cenaCarrega = "Inicio";





    public void CarregaOutraCena()
    {
        SceneManager.LoadScene(cenaCarrega);
    }

}
