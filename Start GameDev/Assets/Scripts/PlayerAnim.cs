using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask enemyLayer;

    private PlayerMove player;
    private Animator anim;

    private casting cast;

    public bool isTalking;
    private bool isHitting;
    private float recoveryTime = 1f; //1 segundo
    private float timeCount;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMove>();
        anim = GetComponent<Animator>();

        cast = FindAnyObjectByType<casting>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();

        if (isHitting) 
        {
            timeCount += Time.deltaTime; //faz com que seja somado em segundos em tempo real

            if (timeCount > recoveryTime)
            {
                isHitting = false;
                timeCount = 0f;
            }
        }

        if (isTalking)
        {
           player.isPaused = true;
        }
        else
        {
           player.isPaused = false;
        }
    }   

    #region movement


    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if(player.isRolling)
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("roll"))
                {
                    anim.SetTrigger("isRoll");
                }
            }
            else
            {
                anim.SetInteger("Transition", 1);
            }
        }
        else
        {
            anim.SetInteger("Transition", 0);
        }

        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if(player.isCutting)
        {
            anim.SetInteger("Transition", 3);
        }

        if (player.isDigging)
        {
            anim.SetInteger("Transition", 4);
        }

        if (player.isWatering)
        {
            anim.SetInteger("Transition", 5);
        }
    }

    void OnRun()
    {
        if (player.isRunning && player.direction.sqrMagnitude > 0)
        {
            anim.SetInteger("Transition", 2); 
        }
    }


    #endregion

    #region Attack

    public void OnAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, enemyLayer);

        if (hit != null) //utilizando "!=" estou dizendo que o hit é diferente de null
        {
            hit.GetComponentInChildren<AnimationControl>().onHit();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }

    #endregion

    //É chamado quando o jogador pressiona o botão de ação na lagoa
    public void OnCastingStarted()
    {
        anim.SetTrigger("isCasting");
        player.isPaused = true;
    }
    //É chamado quando termina a ação de pescaria 
    public void OnCastingEnded()
    {
        cast.OnCasting();
        player.isPaused = false;
    }

    public void OnHammeringStarted()
    {
        anim.SetBool("hammering", true);
    }

    public void OnHammeringEnded()
    {
        anim.SetBool("hammering", false);
    }

    public void OnHit() 
    {
        if (!isHitting) // com ! estou dizendo que é falso
        {
            anim.SetTrigger("hit");
            isHitting = true;
        }
    }
}