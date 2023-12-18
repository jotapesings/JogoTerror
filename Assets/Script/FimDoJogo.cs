using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FimDoJogo : MonoBehaviour
{

    [SerializeField] ControlaPlayer _playerFim;

    [SerializeField] PegaItem _qtd_de_ovos;

    [SerializeField] GameObject _imageOvo2;
    [SerializeField] Text _textOvos;

    [SerializeField] bool ativaFim;

    // Start is called before the first frame update
    void Start()
    {
        _playerFim = FindObjectOfType<ControlaPlayer>();
        _qtd_de_ovos = FindObjectOfType<PegaItem>();
    }

    // Update is called once per frame
    void Update()
    {
        _textOvos.text = _qtd_de_ovos.qtd_ovos.ToString();


        if (_qtd_de_ovos.qtd_ovos == 0 && ativaFim == false)
        {
            StartCoroutine(_playerFim.TempoFimJogo());
            _imageOvo2.SetActive(false);
            ativaFim = true;
        }

    }


}
