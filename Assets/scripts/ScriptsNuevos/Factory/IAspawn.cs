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
    public GameObject[] IAship;
    public float spawnInterval;
    public int spawnQuantity;
    public float nextSpawnTime;
    public bool canSpawn;

    private Factory iaFactory;
    public DataManager dataManager;
    public int multiplier;
    public int num;

    public int spawned;
    private float timer;

    private void Start()
    {
        // Inicializamos la fábrica concreta
        iaFactory = new Factory();
        dataManager = GameObject.FindObjectOfType<DataManager>();
        GetMultiplier();
        num = multiplier * spawnQuantity;
        canSpawn = true;
        nextSpawnTime = 4f;
        timer = 0f;
        spawnInterval = 22f;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (canSpawn && timer >= nextSpawnTime)
        {
            GetMultiplier();
            num = multiplier * spawnQuantity;
            for (int i = 0; i < num; i++)
            {
                SpawnShips(0);
            }

            switch(type)
            {
                case SpawnType.Enemy:
                    dataManager.SetEnemiesToSpawn();
                    for (int i = 0; i < multiplier; i++)
                    {
                        SpawnShips(1);
                        SpawnShips(2);
                    }
                    SpawnShips(3);
                break;
                case SpawnType.PowerUp:
                break;
                default:
                    Debug.Log("Tipo desconocido");
                break;
            }
            
            canSpawn = false;
        }
        else if (!canSpawn)
        {
            GetMultiplier();

            float bias = 0;
            if (multiplier > 2)
                bias = -0.5f;
            else if (multiplier < 2)
                bias = 1.5f;

            nextSpawnTime = timer + ((spawnInterval - (4f * multiplier)) - (6f / multiplier ) - bias);
            canSpawn = true;
        }
    }

    private void SpawnShips(int index)
    {
        if(dataManager.enemiesToSpawn[index])
            iaFactory.CreateIA(IAship[index]);
                    Debug.Log("spawned");
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
