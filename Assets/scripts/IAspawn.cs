using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAspawn : MonoBehaviour
{
    public enum STATE { RELEASE, STAY }
    public STATE state;

    public GameObject IAship;
    public float spawnInterval;
    private float nextSpawnTime;
    private bool canSpawn;

    private IAFactory iaFactory;

    private void Start()
    {
        iaFactory = new IAFactory();
        canSpawn = true;
    }

    void Update()
    {
        if (canSpawn && Time.time >= nextSpawnTime)
        {
            SpawnShips(4); // Genera 4 naves en cada activación
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
