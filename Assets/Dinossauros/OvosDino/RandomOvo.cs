using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOvo : MonoBehaviour
{
    [SerializeField] GameObject[] _ovos;
    [SerializeField] public bool _ativaOvos = false;

    private void Update()
    {
        if (_ativaOvos == true)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < _ovos.Length; i++)
            {
                indices.Add(i);
            }

            for (int i = 0; i < 3; i++)
            {
                int aleatorio = Random.Range(0, indices.Count);
                _ovos[indices[aleatorio]].SetActive(true);
                indices.RemoveAt(aleatorio);
            }
            _ativaOvos = false;
        }
    }
}
