using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public int totalPlayers;

    public GameObject[] HUDObjects;
    public GameObject[] StepObjects;

    public GameObject startHUD;
    public GameObject startStep;

    public GameObject[] GameHUD;

    public void Awake()
    {
        StartAsleep();

        if (startHUD != null )
            startHUD.SetActive(true);
        if (startStep != null )
        startStep.SetActive(true); 
    }

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

    public void StartAsleep()
    {
        foreach (GameObject a in HUDObjects)
        {
            if (a != null)
                a.SetActive(false);
        }
        foreach (GameObject a in StepObjects)
        {
            if (a == null);
                a.SetActive(false);
        }
    }
}
