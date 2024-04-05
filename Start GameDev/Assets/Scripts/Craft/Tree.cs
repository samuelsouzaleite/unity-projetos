using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;

    public void OnHit()
    {
        treeHealth--;

        anim.SetTrigger("isHit");

        if (treeHealth <= 0) 
        {
            //cria o toco e instancia os drops (madeira)
            anim.SetTrigger("cut");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Axe"))
        {
            OnHit();
        }
    }
}
    