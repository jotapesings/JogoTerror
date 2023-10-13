using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portas : MonoBehaviour
{
    [SerializeField] Animator _anim;

    [SerializeField] bool PortaAtivada = false;

    private void Start()
    {

    }


    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player") && PortaAtivada == false)
        {
            
            StartCoroutine(TimePortaAberta());
            
        }

        if(col.gameObject.CompareTag("Player") && PortaAtivada == true)
        {
            StartCoroutine(TimePortaFechada());
            
        }
    }

    private IEnumerator TimePortaAberta()
    {
        _anim.Play("AbrePorta");
        yield return new WaitForSeconds(5f);
        PortaAtivada = true;
    }

    private IEnumerator TimePortaFechada()
    {
        _anim.Play("FechaPorta");
        yield return new WaitForSeconds(5f);
        PortaAtivada = false;
    }

}
