using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControle : MonoBehaviour
{

    public Lanterna _lanterna;
    public GameObject _objetoLanterna;
    public TMP_Text[] _textoDosItens;

    // Start is called before the first frame update
    void Start()
    {

        _lanterna = FindAnyObjectByType<Lanterna>();
        _lanterna._desativaGlobal = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
