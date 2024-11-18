using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // se necesita esta para que funcione la IA
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

    public float health = 10;// indica la vida de la IA

    private IState currentState;// estado actual
    public PatrolState patrolState;//patrullando
    public ChaseState chaseState;// siguiendo
    public AttackState attackState;// atacando
    public DeadState deadState;// explotando

    private float end;
    private float timer;

    private void Awake()
    {
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
        
        timer = 60;
        end = Time.time + timer;
    }

    private void Update()
    {
        currentState.Execute();

        if (health <= 0 || Time.time >= end)//condiciones de muerte
        {
            ChangeState(deadState);
        }
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // si colisiona con un objeto jugador
        {
            health -= 5;
        }
        else if (collision.gameObject.CompareTag("Normal_shoot")) // si colisiona con un objeto disparo normal
        {
            health -= 5;
        }
        else if (collision.gameObject.CompareTag("Heavy_shoot")) // si colisiona con un objeto disparo fuerte
        { // aparecer� 5 fragmentos y desaparecer�

            for (int i = 0; i < 5; i++)
            Instantiate(fragment, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Asteroid")) // si colisiona con un objeto asteroide
        {
            health -= 5;
        }
    }
}