using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PapelDialogO : MonoBehaviour
{

    [SerializeField] Text _dialogoPapel;
    [SerializeField] string[] _textoDialogoPapel;

    bool continuar = true;
    int contador = 0;

    int index;

    public bool _ativaDialogoPapel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_ativaDialogoPapel == true)
        {
            _ativaDialogoPapel = false;
            StartCoroutine(DialogoPapel());
        }
    }


    IEnumerator DialogoPapel()
    {

        while (continuar)
        {
            _dialogoPapel.text = ""; // Limpa o texto
            _dialogoPapel.DOFade(1, 0.1f); // Garante que o texto esteja visível
            _dialogoPapel.DOText(_textoDialogoPapel[contador], 2f);
            yield return new WaitForSeconds(6f);
            yield return _dialogoPapel.DOFade(0, 1f).WaitForCompletion(); // Faz o texto desaparecer

            contador++;

            if (contador >= _textoDialogoPapel.Length)
            {
                continuar = false;

            }
        }


    }



}
