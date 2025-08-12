using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IASpawn : MonoBehaviour
{
    public enum SpawnType
    {
        Enemy,
        PowerUp
    }

    public SpawnType type;
    public GameObject IAship;
    public float spawnInterval;
    public int spawnQuantity;
    public float nextSpawnTime;
    public bool canSpawn;

    private Factory iaFactory;
    public DataManager dataManager;
    public int multiplier;
    public int num;

    public int spawned;

    private void Start()
    {
        // Inicializamos la fábrica concreta
        iaFactory = new Factory();
        dataManager = GameObject.FindObjectOfType<DataManager>();
        GetMultiplier();
        num = multiplier * spawnQuantity;
        canSpawn = true;
    }

    private void Update()
    {

        if (canSpawn && Time.time >= nextSpawnTime)
        {
            if (spawned < num)
            {
                canSpawn = false;
                GetMultiplier();
                num = multiplier * spawnQuantity;

                for (int i = 0; i < num; i++)
                {
                    SpawnShips();
                }
            }
        }
        else if (!canSpawn)
        {
            GetMultiplier();
            nextSpawnTime = Time.time + spawnInterval * (2 / multiplier);
            canSpawn = true;
        }
    }

    private void SpawnShips()
    {
        
        iaFactory.CreateIA(IAship);
        spawned++;
    }

    private void GetMultiplier()
    {
        switch(type)
    {
        case SpawnType.Enemy:
                multiplier = dataManager.EnemiesMultiplier;
            break;
        case SpawnType.PowerUp:
                multiplier = dataManager.powerUpSpawnMultiplier;
            break;
        default:
            Debug.Log("Tipo desconocido");
            break;
    }
    }
}
