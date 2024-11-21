using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class IAEnemiga : MonoBehaviour
{
    public NavMeshAgent agent;// a esta variable se le asigna el "terreno" donde se mueve la IA
    public Transform player1;    // a esta variable se le asigna la ubicacion del jugador 1
    public Transform player2;   // a esta variable se le asigna la ubicacion del jugador 2

    public GameObject fragment; // indica los objetos que apareceran al desaparecer
    public GameObject plasma;   // indica el objeto que dispara
    public GameObject shoot;    // indica el objeto desde donde dispara
    
    public float timebetweenattacks; //indica el tiempo entre sus ataques
    public float sightrange;  // indica el rango para "ver" al jugador
    public float attackrange; // indica el rango para atacar al jugador

    private IState currentState;// estado actual
    public PatrolState patrolState;//patrullando
    public ChaseState chaseState;// siguiendo
    public AttackState attackState;// atacando
    public DeadState deadState;// explotando
    
    public PlayerObjectPool ObjectPool;

    private void Awake()
    {
        ObjectPool = GetComponent<PlayerObjectPool>();
        ObjectPool.prefab = plasma;
        agent = GetComponent<NavMeshAgent>();// asigna el "terreno" donde se mueve la IA
        player1 = GameObject.FindWithTag("Player").transform;// asigna la ubicacion del jugador 1
        player2 = GameObject.FindWithTag("Player2").transform;// asigna la ubicacion del jugador 2

        patrolState = new PatrolState(this);
        chaseState = new ChaseState(this);
        attackState = new AttackState(this);
        deadState = new DeadState(this);
    }

    private void Start()
    {
        ChangeState(patrolState); // Empezar patrullando
    }

    private void Update()
    {
        currentState.Execute();
    }

    public void ChangeState(IState newState)
    {
        currentState?.Exit(); // Salir del estado actual si existe
        currentState = newState;
        currentState.Enter(); // Entrar al nuevo estado
    }

    public void ResetAttack()
    {
        if (currentState is AttackState attackState)
        {
            attackState.ResetAttack();
        }
    }
}