using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirarFoto : MonoBehaviour
{   

     void OnMouseDown()
    {
        // Especifique o nome do arquivo da imagem
        string imageName = "mapa.png";

        // Capture a imagem
        ScreenCapture.CaptureScreenshot(imageName);
    }
}
