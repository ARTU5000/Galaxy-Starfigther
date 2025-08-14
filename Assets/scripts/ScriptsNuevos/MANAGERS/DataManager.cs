using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class DataManager : MonoBehaviour
{
    public int maxPlayTime;//tiempo maximo de juego

    public int totalPoint;
    public List<GameObject> Players = new List<GameObject>(); //referencia a los jugadores
    public List<int> PlayerLifes = new List<int>();
    public int totalLifes;

    public Survival gamemode; //modo de juego
    public float expectedDeathTime; //tiempo de muerte estimado
    public float lastExpectedDeathTime;
    public float lastGeneralDeath; //ultima baja
    public float currentDeath; //Baja a desarrollar
    public int currentPlayerDown; //Jugador en cuestion
    public List<float> lastPlayerDeath = new List<float>(); //lista de tiempos de muertes de jugadores

    public int totalEnemiesDown;//total de enemigos eliminados
    public List<int> totalEnemyOfTypeDown = new List<int>(); //total de enemigos de cada tipo eliminados eliminados
    public bool[] enemiesToSpawn;
    public int EnemiesMultiplier;

    public float dificultyMultiplier;//multiplicador de dificultad
    public int dificulty;//Dificultad asignada para calcular

    public int asteroidSpawnMultiplier;

    public int powerUpSpawnMultiplier;

    public List<float> BossTime = new List<float>();
    public int Bosses;


    // Start is called before the first frame update
    void Start()
    {
        CalculateDeathTime(maxPlayTime);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerDown(float deathTime, int playerNum)//este void lo llama el jugador
    {
        currentDeath = deathTime;
        currentPlayerDown = playerNum;//cada jugador tiene un numero asignado y lo proporciona
        lastExpectedDeathTime = expectedDeathTime;
        
        float reamainingTime = maxPlayTime - currentDeath;
        CalculateDeathTime(reamainingTime); //consigo nuevo expectedDeathTime

        float deathTimeDifference = expectedDeathTime - lastExpectedDeathTime;
        float normalizedDifference = Mathf.Max(0, deathTimeDifference / maxPlayTime);

        if (lastPlayerDeath[currentPlayerDown] == lastGeneralDeath)
            dificultyMultiplier = (normalizedDifference * (2 * dificulty) / 3) / (1 + (normalizedDifference * (2 * dificulty) / 3) / 5);
        else
            dificultyMultiplier = (normalizedDifference * dificulty) / (1 + (normalizedDifference * dificulty) / 5);

        ApplyMultiplier();

        lastPlayerDeath[currentPlayerDown] = currentDeath;
        lastGeneralDeath = currentDeath;
    }

    public void ApplyMultiplier()
    {
        EnemiesMultiplier = (int)Math.Truncate(2 * (dificultyMultiplier + 1));

        asteroidSpawnMultiplier = (int)Math.Truncate(5 * (dificultyMultiplier + 2));
        
        powerUpSpawnMultiplier = (int)Math.Truncate (dificultyMultiplier + 1);
    }

    public void SetRemainingLifes(int playerNum, float lifes)
    {
        PlayerLifes[playerNum] = (int)lifes;
        
        CalculateDeathTime(maxPlayTime - Time.time);
    }

    public void SetDificulty(int _dificulty)
    {
        dificulty = _dificulty;
        EnemiesMultiplier = dificulty;
        asteroidSpawnMultiplier = dificulty;
        powerUpSpawnMultiplier = dificulty;
        Bosses = dificulty;
    }

    public void SetMaxPlayTime(int time)
    {
        BossTime.Clear();
        maxPlayTime = time;
        SetBosstime();
    }


    //Formulas para la euristica
    public void CalculateDeathTime(float remainingTime)
    {
        foreach (int a in PlayerLifes)
            totalLifes += a;

        expectedDeathTime = remainingTime / ((totalLifes  - Players.Count) / dificulty);
    }

    public void SetBosstime()
    {
        for (int i = 0; i < dificulty; i++)
        {
            BossTime.Add(UnityEngine.Random.Range(20, maxPlayTime - 20));
        }
        BossTime.Sort();
    }

    public void SetEnemiesToSpawn()
    {
        if (Time.time < maxPlayTime - 5)
            enemiesToSpawn[0] = true;
        else 
            enemiesToSpawn[0] = false;

        
        if ((Time.time > (maxPlayTime / 2) && EnemiesMultiplier >= 2) || (Time.time > ((2 * maxPlayTime) / 3) && EnemiesMultiplier > 1))
            enemiesToSpawn[1] = true;
        else 
            enemiesToSpawn[1] = false;
            
        if ((Time.time > ((2 * maxPlayTime) / 3) && EnemiesMultiplier >= 3) || Time.time > ((3 * maxPlayTime) / 4) && EnemiesMultiplier >= 2)
            enemiesToSpawn[2] = true;
        else 
            enemiesToSpawn[2] = false;
            
        if (BossTime != null && BossTime.Count > 0)
        {
            if (Time.time >= BossTime[0])
            {
                enemiesToSpawn[3] = true;
                BossTime.RemoveAt(0);
            }
            else
                enemiesToSpawn[3] = false;
        }
        else
            enemiesToSpawn[3] = false;
    }
}
