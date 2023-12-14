using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;
using TMPro;

public class GameControle : MonoBehaviour
{



    public AudioSource _musicaAmbiente;

    public Rig _rigMao;

    public Lanterna _lanterna;
    public GameObject _objetoLanterna;
    public TMP_Text[] _textoDosItens;


    // Start is called before the first frame update
    void Start()
    {
        _lanterna = FindObjectOfType<Lanterna>();
        _lanterna._desativaGlobal = true;
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
