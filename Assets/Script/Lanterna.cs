using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lanterna : MonoBehaviour
{
    [SerializeField] public bool _desativaGlobal;

    [SerializeField] Light _lanterna;
    [SerializeField] bool ativaL = false;

    // Start is called before the first frame update
    void Awake()
    {
        _lanterna = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetLanternaFoco(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            _lanterna.spotAngle = 30f;
            _lanterna.range = 120f;
        }

        if(context.canceled)
        {
            _lanterna.spotAngle = 80f;
            _lanterna.range = 20f;
        }
    }

    public void SetLanterna(InputAction.CallbackContext value)
    {
        if (ativaL == false && _desativaGlobal == false)
        {
            _lanterna.intensity = 3;
            ativaL = true;
        }
        else if (ativaL == true && _desativaGlobal == false)
        {
            _lanterna.intensity = 0;
            ativaL = false;
        }
    }


}
