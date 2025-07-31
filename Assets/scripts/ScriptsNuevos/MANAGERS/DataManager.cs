using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public int maxPlayTime;//tiempo maximo de juego
    float currentTime;

    public int totalPoint;
    public List<GameObject> Players = new List<GameObject>(); //referencia a los jugadores
    public List<int> PlayerLifes = new List<int>();
    public int totalLifes;

    public Survival gamemode; //modo de juego
    public float expectedDeathTime;
    public float lastGeneralDeath;
    public float currentDeath; //Baja a desarrollar
    public int currentPlayerDown; //Jugador en cuestion
    public List<float> lastPlayerDeath = new List<float>();

    public int totalEnemiesDown;//total de enemigos eliminados
    public List<int> totalEnemyOfTypeDown = new List<int>(); //total de enemigos de cada tipo eliminados eliminados
    public bool[] enemiesToSpawn;

    public float dificultyMultiplier;
    public float dificulty;//Dificultad asignada para calcular

    public int asteroidSpawnMultiplier;

    public int powerUpSpawnMultiplier;


    // Start is called before the first frame update
    void Start()
    {
        CalculateDeathTime(maxPlayTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerDown(float deathTime, int playerNum)
    {
        currentDeath = deathTime;
        currentPlayerDown = playerNum;
    }

    public void SetRemainingLifes(int playerNum, float lifes)
    {
        PlayerLifes[playerNum] = (int)lifes;
    }

    public void SetDificulty(int _dificulty)
    {
        dificulty = _dificulty;
    }

    public void SetMaxPlayTime(int time)
    {
        maxPlayTime = time;
    }


    //Formulas para la euristica
    public void CalculateDeathTime(float remainingTime)
    {
        foreach (int a in PlayerLifes)
            totalLifes += a;

        expectedDeathTime = remainingTime / ((totalLifes / dificulty) - Players.Count);
    }
}
