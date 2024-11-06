using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // se necesita esta para que funcione la IA
using UnityEngine.UI;

public class IAEnemiga : MonoBehaviour
{
    public NavMeshAgent enemy;  // a esta variable se le asigna el "terreno" donde se mueve la IA
    public Transform player;    // a esta variable se le asigna la ubicacion del jugador 1
    public Transform player2;   // a esta variable se le asigna la ubicacion del jugador 2

    float ppx;     // posicion del jugador 1 en x
    float ppz;     // posicion del jugador 1 en z
    float p2px;    // posicion del jugador 2 en x
    float p2pz;    // posicion del jugador 2 en z
    float iapx;    // posicion de la IA en x
    float iapz;    // posicion de la IA en z
    float diap1x;  // distancia de la IA con el jugador 1 en x
    float diap1z;  // distancia de la IA con el jugador 1 en z
    float diap2x;  // distancia de la IA con el jugador 2 en x
    float diap2z;  // distancia de la IA con el jugador 2 en z

    public LayerMask wiground; // indica que es "suelo"
    public LayerMask py1;      // indica que es jugador 1
    public LayerMask py2;      // indica que es jugador 2
    LayerMask wiplayer;        // indica que jugador seguira

    private float health = 10;  // indica la vida de la IA
    public GameObject fragment; // indica los objetos que apareceran al desaparecer
    public GameObject plasma;   // indica el objeto que dispara
    public GameObject shoot;    // indica el objeto desde donde dispara

    public Vector3 walkpoint; // indica la posicion a donde se dirige
    bool wpset;               // indica si ya tiene a donde moverse

    public float timebetweenattacks; //indica el tiempo entre sus ataques
    bool attacked;                   //indica si ya atacó

    public float sightrange;  // indica el rango para "ver" al jugador
    public float attackrange; // indica el rango para atacar al jugador
    public bool playerisr;    // indica si el jugador esta aa la vista
    public bool playeriar;    // indica si el jugador esta en rango de ataque

    float randomZ; // indica el valor de z
    float randomX; // indica el valor de x

    private float timer;
    private float end;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;   // asigna la ubicacion del jugador 1
        player2 = GameObject.FindWithTag("Player2").transform; // asigna la ubicacion del jugador 2
        enemy = GetComponent<NavMeshAgent>();                  // asigna el "terreno" donde se mueve la IA


        timer = 60;
        end = Time.time + timer;
    }

    void Update()
    {
        ppx = player.transform.position.x;   // posicion del jugador 1 en x
        ppz = player.transform.position.z;   // posicion del jugador 1 en z
        p2px = player2.transform.position.x; // posicion del jugador 2 en x
        p2pz = player2.transform.position.z; // posicion del jugador 2 en z
        iapx = this.transform.position.x;    // posicion de la IA en x
        iapz = this.transform.position.z;    // posicion de la IA en z

        randomZ = Random.Range(-95, 60); // indica el valor de z
        randomX = Random.Range(-140, 140); // indica el valor de x

        diap1x = Mathf.Abs(iapx - ppx);  // distancia de la IA con el jugador 1 en x
        diap1z = Mathf.Abs(iapz - ppz);  // distancia de la IA con el jugador 1 en z
        diap2x = Mathf.Abs(iapx - p2px); // distancia de la IA con el jugador 2 en x
        diap2z = Mathf.Abs(iapz - p2pz); // distancia de la IA con el jugador 2 en z

        if (diap1x < diap2x && diap1z < diap2z)      // si el jugador 1 esta mas cerca
        {
            wiplayer = py1;                          // seguira al jugador 1
        }
        else if (diap1x > diap2x && diap1z > diap2z) // si el jugador 2 esta mas cerca
        {
            wiplayer = py2;                          // seguira al jugador 2
        }

        playerisr = Physics.CheckSphere(transform.position, sightrange, wiplayer);  // revisa si el jugador esta en el rango de vision
        playeriar = Physics.CheckSphere(transform.position, attackrange, wiplayer); // revisa si el jugador esta en rango de ataque

        if (!playerisr && !playeriar) // si el jugador no esta en rango de vista ni rango de ataque
        {
            Patrol();                 // la IA patrullará
        }

        if (playerisr && !playeriar) // si el jugador esta en rango de visión pero no en rango de ataque
        {
            chase();                 // la IA perseguirá al jugador
            wpset = false;
        }

        if (playerisr && playeriar) // si el jugador esta en rango de vision y de ataque 
        {
            attack();               // la IA atacará al jugador
            wpset = false;
        }

        if (Time.time >= end)
        {
            health = 0;
        }

        if (health <= 0) // si la vida de la IA llega a 0 aparecerá 5 fragmentos y desaparecerá
        {
            
            Instantiate(fragment, transform.position, Quaternion.identity);
            Instantiate(fragment, transform.position, Quaternion.identity);
            Instantiate(fragment, transform.position, Quaternion.identity);
            Instantiate(fragment, transform.position, Quaternion.identity);
            Instantiate(fragment, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void Patrol() 
    {
        if(!wpset) // si aun no tiene a donde moverse
        {
            searchwp(); // buscará coordenadas a donde dirijirse
        }
        if (wpset) // si ya tiene a donde moverse
        {
            enemy.SetDestination(walkpoint); // se dirijirá a dicho lugar
        }

        Vector3 distancetowalkpoint = transform.position - walkpoint; // la distancia al punto sera la posicion de la IA menos la posicon del  objetivo

        if(distancetowalkpoint.magnitude <= 1f) // cuando la distancia al objetivo sea igual o menor a 1 buscará nuevas coordenadas
        {
            wpset = false;
        }
    }

    private void searchwp() // IMPORTANTE: esta funcion aun no sirve completamente
    {
        

        walkpoint = new Vector3(randomX, transform.position.y,randomZ); //indica la ubicación a donde se moverá

        wpset = true;                                         // se movera a dichas coordenadas
        
    }

    private void chase()
    {
        if (wiplayer == py1)                        // si sigue al jugador 1
        {
            enemy.SetDestination(player.position);  // se movera hacia el jugador 1
        }
        else if (wiplayer == py2)                   // si sigue al jugador 2
        {
            enemy.SetDestination(player2.position); // se movera hacia el jugador 2
        }
    }

    private void attack()
    {
        if (wiplayer == py1)                        // si sigue al jugador 1
        {
            enemy.SetDestination(player.position);  // se movera hacia el jugador 1
            transform.LookAt(player.position);      // "mirará" hacia el jugador 1
        }
        else if (wiplayer == py2)                   // si sigue al jugador 2
        {
            enemy.SetDestination(player2.position); // se movera hacia el jugador 2
            transform.LookAt(player2.position);     // "mirará" hacia el jugador 2
        }

        if(!attacked) // si aun no ha atacado
        {
            Instantiate(plasma, shoot.transform.position, shoot.transform.rotation); //aparecera un objeto proyectil
            attacked = true; // marcara como que ya atacó
            Invoke(nameof(resetattack), timebetweenattacks); // se llamara a la funcion despues de cierto tiempo
        }
    }

    private void resetattack()
    {
        attacked = false; // marcará como que aun no ataca
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // si colisiona con un objeto jugador
        {
            health--;
            health--;
            health--;
            health--;
            health--;
        }
        else if (collision.gameObject.CompareTag("Normal_shoot")) // si colisiona con un objeto disparo normal
        {
            health--;
            health--;
            health--;
            health--;
            health--;
        }
        else if (collision.gameObject.CompareTag("Heavy_shoot")) // si colisiona con un objeto disparo fuerte
        { // aparecerá 5 fragmentos y desaparecerá


            Instantiate(fragment, transform.position, Quaternion.identity);
            Instantiate(fragment, transform.position, Quaternion.identity);
            Instantiate(fragment, transform.position, Quaternion.identity);
            Instantiate(fragment, transform.position, Quaternion.identity);
            Instantiate(fragment, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Asteroid")) // si colisiona con un objeto asteroide
        {
            health--;
            health--;
            health--;
            health--;
            health--;
        }
    }
}
