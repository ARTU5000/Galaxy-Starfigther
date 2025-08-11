using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILife : MonoBehaviour
{
    public float health;// indica la vida de la IA
    //public IAEnemiga ai;
    public Enemy ai;
    [SerializeField] private float end;
    private float timer;
    public DataManager dataManager;
    public int multiplier;

     private void Awake()
    {
        //ai = GetComponent<IAEnemiga>();
        ai = GetComponent<Enemy>();
    }
    
    private void Start()
    {
        timer = 45;
        end = Time.time + timer;
        dataManager = GameObject.FindObjectOfType<DataManager>();
        multiplier = dataManager.EnemiesMultiplier;
        health = 10 * multiplier;
    }
    
    private void Update()
    {
        if (health <= 0 || Time.time >= end)//condiciones de muerte
        {
            //ai.ChangeState(ai.deadState);
            ai.machine.ChangeState(EStates.Die);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))//colisiona con un jugador
        {
            health -= 5;
        }
        else if (collision.gameObject.CompareTag("Normal_shoot"))//colisiona con un disparo normal
        {
            health -= 5;
        }
        else if (collision.gameObject.CompareTag("Asteroid"))//colisiona con un asteroide
        {
            health -= 5;
        }
        else if (collision.gameObject.CompareTag("Heavy_shoot"))//colisiona con un disparo fuerte
        {
            //ai.ChangeState(ai.deadState);
            ai.machine.ChangeState(EStates.Die);
        }
    }
}
