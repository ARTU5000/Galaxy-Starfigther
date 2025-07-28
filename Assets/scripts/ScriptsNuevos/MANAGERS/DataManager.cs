using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public int maxPlayTime;//tiempo maximo de juego
    public int totalPoint;
    public List<GameObject> Players = new List<GameObject>(); //referencia a los jugadores

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

    public void SetDificulty(int _dificulty)
    {
        dificulty = _dificulty;
    }

    public void SetMaxPlayTime(int time)
    {
        maxPlayTime = time;
    }
}
