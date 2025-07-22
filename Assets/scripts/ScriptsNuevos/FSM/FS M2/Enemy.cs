using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;// a esta varle se le asigna el "terreno" donde se mueve la     
    //public Transform player1;    // a esta varle se le asigna la ubicacion del jugador 1
    //public Transform player2;   // a esta varle se le asigna la ubicacion del jugador 2

    public GameObject[] players;

    public GameObject fragment; // indica los objetos que apareceran al desaparecer
    public GameObject plasma;   // indica el objeto que dispara
    public GameObject shoot;    // indica el objeto desde donde dispara
    
    public float timebetweenattacks; //indica el tiempo entre sus ataques
    public float sightrange;  // indica el rango para "ver" al jugador
    public float attackrange; // indica el rango para atacar al jugador

    public Machine machine;// estado actual
    
    public PlayerObjectPool ObjectPool;
    private bool attacked;
    public Transform target;
    private Vector3 walkpoint;

    private void Awake()
    {
        ObjectPool = GetComponent<PlayerObjectPool>();
        ObjectPool.prefab = plasma;
        agent = GetComponent<NavMeshAgent>();// asigna el "terreno" donde se mueve la         
        //player1 = GameObject.FindWithTag("Player").transform;// asigna la ubicacion del jugador 1
        //player2 = GameObject.FindWithTag("Player2").transform;// asigna la ubicacion del jugador 2

        players = GameObject.FindGameObjectsWithTag("Player");

        machine.setIA(this);
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (machine.currentState == EStates.Patrol)
        {
            if (Vector3.Distance(walkpoint, agent.transform.position) <= 20f)
            {
                SetWalkPoint();
            }

            agent.SetDestination(walkpoint);
        }
        else if (machine.currentState == EStates.Follow)
        {
            target = GetClosestPlayer();

            if (target != null)
            {
                agent.SetDestination(target.position);
                transform.LookAt(target.position);
            }
        }
        else if (machine.currentState == EStates.Attack)
        {
            if (!attacked)
            {
                GameObject projectile = ObjectPool.Spawn();
                if (projectile != null)
                {
                    projectile.transform.position = shoot.transform.position;
                    projectile.transform.rotation = shoot.transform.rotation;
                }
                attacked = true;
                Invoke(nameof(ResetAttack), timebetweenattacks);
            }

            target = GetClosestPlayer();
            agent.SetDestination(target.position);
            transform.LookAt(target.position);   
        }
        else if (machine.currentState == EStates.Die)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject.Instantiate(fragment, transform.position, Quaternion.identity);
            }

            ObjectPool.DestroyAll();
            GameObject.Destroy(gameObject);
        }
    }

    public void ResetAttack()
    {
        attacked = false;
    }

    private void SetWalkPoint()// busca coordenadas a donde dirijirse
    {
        float randomX = Random.Range(-140, 140);
        float randomZ = Random.Range(-95, 60);
        walkpoint = new Vector3(randomX, transform.position.y, randomZ);
    }
    public Transform GetClosestPlayer()// busca coordenadas a donde dirijirse
    {

        float distanceToPlayer = float.MaxValue;
        int closest = 0;

        players = GameObject.FindGameObjectsWithTag("Player");//Temporal hasta tener condiciones de victoria y derrota

        // Verifica si hay jugadores
        if (players.Length == 0)
            return null;
    
        for (int i = 0; i < players.Length; i++)
        {
            float distanceToPlayerI = Vector3.Distance(players[i].transform.position, agent.transform.position);
            if (distanceToPlayerI < distanceToPlayer)
            {
                distanceToPlayer = distanceToPlayerI;
                closest = i;
            }
        }

        return players[closest].transform;
    }
}
