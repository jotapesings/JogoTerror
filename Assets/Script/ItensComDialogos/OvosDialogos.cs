using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OvosDialogos : MonoBehaviour
{

    [SerializeField] AudioSource _vozFalaOvo;
    [SerializeField] AudioClip[] _bibliotecaOvos;

    [SerializeField] Text _dialogoOvo;
    [SerializeField] string[] _textoDialogoOvo;

    public bool continuar = true;
    public bool novoContinuar = true;

    [SerializeField] int contador = 0;
    [SerializeField] int novoContador = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        

    }


    public IEnumerator DialogoOvo()
    {

        while (continuar)
        {
            _dialogoOvo.text = ""; // Limpa o texto
            _dialogoOvo.DOFade(1, 0.1f); // Garante que o texto esteja visível
            _dialogoOvo.DOText(_textoDialogoOvo[contador], 2f);
            _vozFalaOvo.PlayOneShot(_bibliotecaOvos[contador]);
            yield return new WaitForSeconds(6f);
            yield return _dialogoOvo.DOFade(0, 1f).WaitForCompletion(); // Faz o texto desaparecer
            continuar = false;
            contador += 1;
        }


    }

    public IEnumerator OutraCorroutina()
    {
        while (novoContinuar)
        {
            _dialogoOvo.text = ""; // Limpa o texto
            _dialogoOvo.DOFade(1, 0.1f); // Garante que o texto esteja visível
            _dialogoOvo.DOText(_textoDialogoOvo[novoContador], 2f);
            _vozFalaOvo.PlayOneShot(_bibliotecaOvos[novoContador]);
            yield return new WaitForSeconds(6f);
            yield return _dialogoOvo.DOFade(0, 1f).WaitForCompletion(); // Faz o texto desaparecer
            novoContador += 1;

        }

        if (novoContador >= _textoDialogoOvo.Length);
        {
            novoContinuar = false;

        }

    }





}