using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaCamera : MonoBehaviour
{

    [SerializeField] GameObject[] _telas;

   


    // Start is called before the first frame update
    void Start()
    {
        _telas[1].SetActive(false);
        _telas[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void camera1()
    {
        _telas[0].SetActive(true);
        _telas[1].SetActive(false);
        _telas[2].SetActive(false);

    }

    public void camera2()
    {
        _telas[0].SetActive(false);
        _telas[1].SetActive(true);
        _telas[2].SetActive(false);

    }

    public void camera3()
    {
        _telas[0].SetActive(false);
        _telas[1].SetActive(false);
        _telas[2].SetActive(true);

    }


}
