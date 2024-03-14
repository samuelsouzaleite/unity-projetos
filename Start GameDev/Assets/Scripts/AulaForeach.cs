using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AulaForeach : MonoBehaviour
{
    //For é um laço/loop de repetição

    /*
    Laço (loop) de repetição  é uma estrutura que executa um conjunto e instruções
    enquanto uma determinada condição é verdadeira.
     */

    public int[] arrayInt = { 1, 2, 3, 4, 5 };
    void Start()
    {
        //for(valor inicial; condição final; valor incremento)
        //for(int i = 0; i < 10; i++)
        //{
        //    Debug.Log(i);
        //}

        foreach (int valor in arrayInt)
        {
            Debug.Log(valor);
        }

    }
}
