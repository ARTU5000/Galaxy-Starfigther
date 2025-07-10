using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IASpawn : MonoBehaviour
{
    public GameObject IAship;
    public float spawnInterval;
    public int spawnQuantity;
    private float nextSpawnTime;
    private bool canSpawn;

    private Factory iaFactory;

    private void Start()
    {
        // Inicializamos la fábrica concreta
        iaFactory = new Factory();
        canSpawn = true;
    }

    private void Update()
    {
        if (canSpawn && Time.time >= nextSpawnTime)
        {
            SpawnShips(spawnQuantity);
            canSpawn = false;
        }
        else if (!canSpawn)
        {
            nextSpawnTime = Time.time + spawnInterval;
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
}
