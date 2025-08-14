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
            canSpawn = false;
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
                default:
                    Debug.Log("Tipo desconocido");
                break;
            }
        }
        else if (!canSpawn)
        {
            GetMultiplier();
            nextSpawnTime = Time.time + spawnInterval * (2f / multiplier);
            canSpawn = true;
        }
    }

    private void SpawnShips(int index)
    {
        if(dataManager.enemiesToSpawn[index])
            iaFactory.CreateIA(IAship[index]);
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
