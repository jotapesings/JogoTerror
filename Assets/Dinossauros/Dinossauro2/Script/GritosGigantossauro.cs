using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GritosGigantossauro : MonoBehaviour
{


    [SerializeField] AudioSource _gritos;
    [SerializeField] AudioClip[] _bibliotecaGritos;

    [SerializeField] int index;


    public void GritosGigante()
    {
        _gritos.PlayOneShot(_bibliotecaGritos[Random.Range(0, _bibliotecaGritos.Length)]);
    }

}
