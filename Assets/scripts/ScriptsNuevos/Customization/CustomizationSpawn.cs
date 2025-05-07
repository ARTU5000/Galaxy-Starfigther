using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationSpawn : MonoBehaviour
{

    public GameObject playerPrefab; // Prefab del objeto a instanciar
    public GameObject CustomizatorParent;
    string coloredPlane = "Plane.001";
    public Material[] materials;
    public int totalPlayers;

    public gameManager manager;

    List<GameObject> playerPool = new List<GameObject>();

    int[] playerColors;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<gameManager>();
        totalPlayers = manager.totalPlayers;

        for (int i = 0; i < totalPlayers; i++)
        {
            GameObject player = Instantiate(playerPrefab, this.transform);
            GoToStartPosition(totalPlayers, i, player);
            playerPool.Add(player);
            AssignMaterial(i, player);
            CuatomizatorToCanvas(i, player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CuatomizatorToCanvas(int playerNum, GameObject player)
    {
        Transform[] allChildren = player.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in allChildren)
        {
            if (child.name == "Customizator")
            {
                child.transform.SetParent(CustomizatorParent.transform, false);
                HUDStartPosition(totalPlayers, playerNum, child);
            }
        }
    }

    public void AssignMaterial(int playerNum, GameObject player)
    {
        Transform[] allChildren = player.GetComponentsInChildren<Transform>(true);
    
        foreach (Transform child in allChildren)
        {
            if (child.name == coloredPlane)
            {
                child.GetComponent<Renderer>().material = materials[playerNum];
            }
        }

        foreach (Transform child in allChildren)
        {
            if (child.name == "Customizator")
            {
                child.GetComponent<ShipAndColor>().material = materials[playerNum];
                child.GetComponent<ShipAndColor>().playerNum = playerNum;
                break;
            }
        }
    }

    public void GoToStartPosition(int maxPlayers, int playerNum, GameObject player)
    {
        float posY = 5.5f;

        switch ((maxPlayers, playerNum))
        {
            // 1 Jugador
            case (1,0):
                player.transform.position = new Vector3(0, posY, 0);
                break;
            // 2 Jugadores
            case (2, 0):
                player.transform.position = new Vector3(-80, posY, 0);
                break;
            case (2, 1):
                player.transform.position = new Vector3(80, posY, 0);
                break;
            // 3 Jugadores
            case (3, 0):
                player.transform.position = new Vector3(-80, posY, 40);
                break;
            case (3, 1):
                player.transform.position = new Vector3(80, posY, 40);
                break;
            case (3, 2):
                player.transform.position = new Vector3(0, posY, -40);
                break;
            // 4 Jugadores
            case (4, 0):
                player.transform.position = new Vector3(-80, posY, 40);
                break;
            case (4, 1):
                player.transform.position = new Vector3(80, posY, 40);
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

    public void HUDStartPosition(int maxPlayers, int playerNum, Transform selector)
    {
        float posZ = 1f;

        switch ((maxPlayers, playerNum))
        {
            // 1 Jugador
            case (1, 0):
                selector.position = new Vector3(970, 680, posZ);
                break;
            // 2 Jugadores
            case (2, 0):
                selector.position = new Vector3(440, 680, posZ);
                break;
            case (2, 1):
                selector.position = new Vector3(1490, 680, posZ);
                break;
            // 3 Jugadores
            case (3, 0):
                selector.position = new Vector3(440, 940, posZ);
                break;
            case (3, 1):
                selector.position = new Vector3(1490, 940, posZ);
                break;
            case (3, 2):
                selector.position = new Vector3(970, 400, posZ);
                break;
            // 4 Jugadores
            case (4, 0):
                selector.position = new Vector3(440, 940, posZ);
                break;
            case (4, 1):
                selector.position = new Vector3(1490, 940, posZ);
                break;
            case (4, 2):
                selector.position = new Vector3(440, 400, posZ);
                break;
            case (4, 3):
                selector.position = new Vector3(1490, 400, posZ);
                break;
            // No coincide
            default:
                Debug.Log("One or both measurements are not valid.");
                break;
        }
    }
}
