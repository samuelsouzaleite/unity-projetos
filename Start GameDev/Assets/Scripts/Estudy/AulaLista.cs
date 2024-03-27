using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AulaLista : MonoBehaviour
{
    public List<int> Idade = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        Idade.Add(1);
        Idade.Add(2);
        Idade.Add(3);

        //Idade.Remove(1);

        //Idade.Clear();
        
        foreach (int item in Idade)
        {
            Debug.Log(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
