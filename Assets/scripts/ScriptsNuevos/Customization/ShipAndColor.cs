using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipAndColor : MonoBehaviour
{
    public GameObject[] modelos;
    int currentShip;

    public Material material;
    public Material[] materials;
    public Image imageColor;
    public Color color;
    public Color[] colors;
    int currentColor;

    public int playerNum;
    public CustomizationSpawn CS;


    // Start is called before the first frame update
    void Start()
    {
        turnOffModels();
        currentShip = 0;
        modelos[currentShip].gameObject.SetActive(true);
        currentColor = playerNum;
        SetShipColor();
    }

    public void turnOffModels()
    {
        foreach (var A in modelos)
        {
            A.gameObject.SetActive(false);
        }
    }

    public void buttonL()
    {
        turnOffModels();

        currentShip--;
        if (currentShip < 0)
            currentShip = modelos.Length - 1;

        modelos[currentShip].gameObject.SetActive(true);
    }

    public void buttonR()
    {
        turnOffModels();
        currentShip++;
        if (currentShip >= modelos.Length)
            currentShip = 0;

        modelos[currentShip].gameObject.SetActive(true);
    }

    public void SetShipColor()
    {
        color = colors[currentColor];
        imageColor.color = color; 
        material.color = color;
        CS.GameHUDColors[playerNum].color = color;
    }

    public void colorL()
    {
        currentColor--;

        if (currentColor < 0)
            currentColor = colors.Length - 1;

        SetShipColor();
    }

    public void colorR()
    {
        currentColor++;

        if (currentColor >= colors.Length)
            currentColor = 0;

        SetShipColor();
    }
}
