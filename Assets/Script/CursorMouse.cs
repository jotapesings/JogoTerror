using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMouse : MonoBehaviour
{

    [SerializeField] bool CursosDesativado = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            CursosDesativado = true;
        }


        if(CursosDesativado == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
