using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;
using TMPro;

public class GameControle : MonoBehaviour
{

    MovimentoDino2 _ativador;

    public AudioSource _musicaAmbiente;

    public Rig _rigMao;

    public Lanterna _lanterna;
    public GameObject _objetoLanterna;
    public TMP_Text[] _textoDosItens;


    // Start is called before the first frame update
    void Start()
    {
        _ativador = FindObjectOfType<MovimentoDino2>();
        _lanterna = FindObjectOfType<Lanterna>();
        _lanterna._desativaGlobal = true;

        StartCoroutine(AtivaGigantossauro());
    }

    // Update is called once per frame
    void Update()
    {

        
    }


    IEnumerator AtivaGigantossauro()
    {
        yield return new WaitForSeconds(60f);
        _ativador.ativaGigantossauro = true;
    }
}
