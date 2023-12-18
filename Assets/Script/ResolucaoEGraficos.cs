using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolucaoEGraficos : MonoBehaviour
{


    public void Low()
    {
        QualitySettings.SetQualityLevel(1, true);
    }

    public void Medium()
    {
        QualitySettings.SetQualityLevel(2, true);
    }

    public void High()
    {
        QualitySettings.SetQualityLevel(3, true);
    }

    public void Ultra()
    {
        QualitySettings.SetQualityLevel(5, true);
    }

    //Resolução do Jogo

    public void Resolution1280()
    {
        Screen.SetResolution(1280, 720, true);
    }

    public void Resolution1366()
    {
        Screen.SetResolution(1366, 768, true);
    }

    public void Resolution1920()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void Resolution2560()
    {
        Screen.SetResolution(2560, 1440, true);
    }

    public void Resolution3840()
    {
        Screen.SetResolution(3840, 2160, true);
    }


    public void SairCasoPrecise()
    {
        Application.Quit();
    }

}
