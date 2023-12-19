using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OvosDialogos : MonoBehaviour
{

    

    [SerializeField] Text _dialogoOvo;
    [SerializeField] string[] _textoDialogoOvo;

    public bool continuar = true;
    int contador = 0;

    int index;

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
            yield return new WaitForSeconds(6f);
            yield return _dialogoOvo.DOFade(0, 1f).WaitForCompletion(); // Faz o texto desaparecer
            continuar = false;
            contador += 1;
        }


    }



}