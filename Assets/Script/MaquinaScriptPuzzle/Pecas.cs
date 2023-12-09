using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pecas : MonoBehaviour
{

    [SerializeField] PegaItem _item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_item.PegouItem == true)
        {
            gameObject.SetActive(false);
        }
    }


}
