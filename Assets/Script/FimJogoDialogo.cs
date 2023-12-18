using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FimJogoDialogo : MonoBehaviour
{

    [SerializeField] Text _textoDialogo;
    [SerializeField] string[] _dialogoHistoria;


    int index;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IniciaDialogoFinal());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator IniciaDialogoFinal()
    {
        for (int i = 0; i < _dialogoHistoria.Length; i++)
        {
            _textoDialogo.text = "";
            _textoDialogo.DOText(_dialogoHistoria[index], 4f);
            yield return new WaitForSeconds(7f);
            index += 1;
        }
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Menu");
        
    }
}
