using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public int totatPointer;
    public List<GameObject> Players = new List<GameObject>();
    public List<int> Pointer = new List<int>();

    public Time expectedDeath;
    public Time lastGeneralDeath;
    public List<Time> lastPlayerDeath = new List<Time>();

    public int totalEnemiesDown;
    public int enemiesTypesNum;
    public int[] totalEnemyOfTypeDown;
    public bool[] enemiesToSpawn;
    public float dificultyMultiplier;
    public float dificulty;

    public int asteroidsDestroyed;
    public int asteroidSpawnMultiplier;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
