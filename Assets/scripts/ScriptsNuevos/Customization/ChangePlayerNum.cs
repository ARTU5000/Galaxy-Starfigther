using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerNum : MonoBehaviour
{
    gameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToOne()
    {
        manager.totalPlayers = 1;
        manager.CheckTotalPlayersNumber();
    }

    public void ChangeToTwo()
    { 
        manager.totalPlayers = 2;
        manager.CheckTotalPlayersNumber();
    }

    public void ChangeToThree()
    {
        manager.totalPlayers = 3;
        manager.CheckTotalPlayersNumber();
    }

    public void ChangeToFour()
    {
        manager.totalPlayers = 4;
        manager.CheckTotalPlayersNumber();
    }
}
