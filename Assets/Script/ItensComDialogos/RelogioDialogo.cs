using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RelogioDialogo : MonoBehaviour
{

    [SerializeField] AudioSource _vozFinal;
    [SerializeField] AudioClip[] _bibliotecaVozFinal;

    [SerializeField] Text _dialogoRelogio;
    [SerializeField] string[] _textoDialogoRelogio;

    bool continuar = true;
    int contador = 0;

    int index;

    public bool _ativaDialogoRelogio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_ativaDialogoRelogio == true)
        {
            _ativaDialogoRelogio = false;
            StartCoroutine(DialogoRelogio());
        }
    }


    IEnumerator DialogoRelogio()
    {

        while (continuar)
        {
            _dialogoRelogio.text = ""; // Limpa o texto
            _dialogoRelogio.DOFade(1, 0.1f); // Garante que o texto esteja visível
            _dialogoRelogio.DOText(_textoDialogoRelogio[contador], 2f);
            _vozFinal.PlayOneShot(_bibliotecaVozFinal[contador]);
            yield return new WaitForSeconds(4f);
            yield return _dialogoRelogio.DOFade(0, 1f).WaitForCompletion(); // Faz o texto desaparecer

            contador++;

            if (contador >= _textoDialogoRelogio.Length)
            {
                continuar = false;

            }
        }


    }



}
