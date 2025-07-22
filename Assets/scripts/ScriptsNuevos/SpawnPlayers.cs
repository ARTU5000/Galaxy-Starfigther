using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public gameManager manager;
    public CustomizationSpawn customs;

    public GameObject playerPrefab; // Prefab del objeto a instanciar
    public int totalPlayers;

    List<GameObject> playerPool = new List<GameObject>();

    public GameObject[] GameHUD;

    public Survival ruleManager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<gameManager>();
        customs = FindObjectOfType<CustomizationSpawn>();
        totalPlayers = manager.totalPlayers;
        GameHUD = manager.GameHUD;

        for (int i = 0; i < totalPlayers; i++)
        {
            GameObject player = Instantiate(playerPrefab);
            player.GetComponent<PlayerInput>().PlayerNum = i;
            GoToStartPosition(totalPlayers, i, player);
            player.GetComponent<PlayerInput>().AssignControllerInputs();
            GetCustomShip(i, player);
            playerPool.Add(player);
            ruleManager.Players.Add(player);
        }

        customs.gameObject.SetActive(false);
    }

    public void GetCustomShip(int num, GameObject player)
    {
        Transform[] allChildren = customs.playerPool[num].GetComponentsInChildren<Transform>(true);
        foreach (Transform child in allChildren)
        {
            if (child.name == "Modelos")
            {
                child.transform.SetParent(player.transform, false);
                child.localPosition = Vector3.zero;
                child.rotation = Quaternion.identity;
                child.localScale = Vector3.one;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToStartPosition(int maxPlayers, int playerNum, GameObject player)
    {
        float posY = 1.5f;

        switch ((maxPlayers, playerNum))
        {
            // 1 Jugador
            case (1,0):
                player.transform.position = new Vector3(0, posY, -25);
                break;
            // 2 Jugadores
            case (2, 0):
                player.transform.position = new Vector3(-80, posY, -25);
                break;
            case (2, 1):
                player.transform.position = new Vector3(80, posY, -25);
                break;
            // 3 Jugadores
            case (3, 0):
                player.transform.position = new Vector3(-80, posY, 10);
                break;
            case (3, 1):
                player.transform.position = new Vector3(80, posY, 10);
                break;
            case (3, 2):
                player.transform.position = new Vector3(0, posY, -40);
                break;
            // 4 Jugadores
            case (4, 0):
                player.transform.position = new Vector3(-80, posY, 10);
                break;
            case (4, 1):
                player.transform.position = new Vector3(80, posY, 10);
                break;
            case (4, 2):
                player.transform.position = new Vector3(-80, posY, -40);
                break;
            case (4, 3):
                player.transform.position = new Vector3(80, posY, -40);
                break;
            // No coincide
            default:
                Debug.Log("One or both measurements are not valid.");
                break;
        }
    }
    // spawn player
    // limitar jugadores a 4
    //
}
