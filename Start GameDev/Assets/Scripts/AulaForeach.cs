using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AulaForeach : MonoBehaviour
{
    //For � um la�o/loop de repeti��o

    /*
    La�o (loop) de repeti��o  � uma estrutura que executa um conjunto e instru��es
    enquanto uma determinada condi��o � verdadeira.
     */

    public int[] arrayInt = { 1, 2, 3, 4, 5 };
    void Start()
    {
        //for(valor inicial; condi��o final; valor incremento)
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
