using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] Transform target;
    [SerializeField] private AnimationControl animControl;

    //private PlayerMove player;
    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //player = FindObjectOfType<PlayerMove>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

        if (Vector2.Distance(transform.position, target.position) <= agent.stoppingDistance)
        {
            //chegou no limite de distância /skeleton para
            animControl.PlayAnim(2);

        }

        else
        {
            //skeleton segue o player
            animControl.PlayAnim(1);

        }

        float posX = target.transform.position.x - transform.position.x;
        if (posX > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    
}
