using System.Collections;
using System.Collections.Generic;
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
    private bool canSpawn;

    private Factory iaFactory;
    public DataManager dataManager;
    public int multiplier;

    private void Start()
    {
        // Inicializamos la fábrica concreta
        iaFactory = new Factory();
        canSpawn = true;
        dataManager = GameObject.FindObjectOfType<DataManager>();
        GetMultiplier();
    }

    private void Update()
    {

        if (canSpawn && Time.time >= nextSpawnTime)
        {
            GetMultiplier();
            SpawnShips(multiplier * spawnQuantity);
            canSpawn = false;
        }
        else if (!canSpawn)
        {
            GetMultiplier();
            nextSpawnTime = Time.time + spawnInterval * (2 / multiplier);
            canSpawn = true;
        }
    }

    private void SpawnShips(int count)
    {
        for (int i = 0; i < count; i++)
        {
            iaFactory.CreateIA(IAship);
        }
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
