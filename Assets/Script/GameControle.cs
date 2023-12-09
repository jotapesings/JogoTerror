using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControle : MonoBehaviour
{

    private Lanterna _lanterna;

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
