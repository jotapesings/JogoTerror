using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lanterna : MonoBehaviour
{

    [SerializeField] Light _lanterna;
    [SerializeField] bool ativaL = false;

    // Start is called before the first frame update
    void Start()
    {
        _lanterna = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetLanterna(InputAction.CallbackContext value)
    {
        if (ativaL == false)
        {
            _lanterna.intensity = 10;
            ativaL = true;
        }
        else if (ativaL == true)
        {
            _lanterna.intensity = 0;
            ativaL = false;
        }
    }


}
