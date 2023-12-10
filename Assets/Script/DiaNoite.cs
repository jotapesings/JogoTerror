using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaNoite : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] Light _luz;

    // Start is called before the first frame update
    void Start()
    {
        _luz = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

        if(_luz.intensity >= 0.3f)
        {
            _luz.intensity -= _speed * Time.deltaTime;
        }
        


    }
}
