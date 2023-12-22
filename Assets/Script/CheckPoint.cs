using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Transform _player;
    public Vector3 defaultPosition = new Vector3(129.45f, 0.2081816f, 87.24f); // Defina isso para a posi��o inicial desejada

    private void Start()
    {
        if (PlayerPrefs.GetInt("IsFirstPlay", 0) == 0)
        {
            // Se for a primeira vez que o jogo est� sendo iniciado, defina a posi��o do jogador para a posi��o padr�o
            _player.position = defaultPosition;
            PlayerPrefs.SetInt("IsFirstPlay", 1);
        }
        else
        {
            // Se n�o for a primeira vez que o jogo est� sendo iniciado, carregue a posi��o salva
            PointCheckPont();
        }
    }

    public void savaPosicao()
    {
        PlayerPrefs.SetFloat("PlayerPosX", _player.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", _player.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", _player.position.z); // Salva a coordenada z do jogador
    }

    public void PointCheckPont()
    {
        Debug.Log("Jogador morreu, carregando posi��o salva"); // Adicione esta linha

        if (PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY") && PlayerPrefs.HasKey("PlayerPosZ"))
        {
            float x = PlayerPrefs.GetFloat("PlayerPosX");
            float y = PlayerPrefs.GetFloat("PlayerPosY");
            float z = PlayerPrefs.GetFloat("PlayerPosZ"); // Carrega a coordenada z do jogador

            _player.position = new Vector3(x, y, z);
        }
        else
        {
            // Defina a posi��o do jogador para um valor padr�o
            _player.position = defaultPosition;
        }
    }
}




