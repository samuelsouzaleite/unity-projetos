using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AulaIf : MonoBehaviour
{
    public bool IsAlive;
    // Start is called before the first frame update
    void Start()
    {
       /* if(IsAlive == true)
        {
            Debug.Log("Vivo");
        }
        else
        {
            Debug.Log("Morto");
        } */
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Pressionou");
        }
    }
}
