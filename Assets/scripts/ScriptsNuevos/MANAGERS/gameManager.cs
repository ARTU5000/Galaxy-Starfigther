using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public int totalPlayers;

    // Start is called before the first frame update
    void Start()
    {
        CheckTotalPlayersNumber();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckTotalPlayersNumber()
    {
        if (totalPlayers < 1)
            totalPlayers = 1;
        else if (totalPlayers > 4)
            totalPlayers = 4;
    }
}
