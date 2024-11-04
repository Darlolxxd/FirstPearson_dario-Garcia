using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private NavMeshAgent agent;
    private Player player;
    private Animator Animator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDanhable;
    
    //private bool ventaAbierta = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();
        player = GameObject.FindAnyObjectByType<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped= true;
            Animator.SetBool("attacking", true);
            
        }
        //Perseguir();

        //if (ventanaAbierta)
        {
            DetectarPlayer();
        }
        
    }

    private void DetectarPlayer()
    {
        Collider[] collsDetectados = Physics.OverlapSphere(attackPoint.position, radioAtaque,queEsDanhable);
        //Physics.OverlapSphere()
    }
    private void FinAtaque()
    {
        agent.isStopped= false;
        Animator.SetBool("attacking", false);
    }
    private void ventanaAbierta()
    {

    }
    private void ventanaCerrada()
    {

    }
    

    
}
