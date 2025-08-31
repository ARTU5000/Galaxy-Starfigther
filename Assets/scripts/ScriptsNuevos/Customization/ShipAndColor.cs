using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

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

    private Gamepad gamepad;
    private bool lbWasPressed = false;
    private bool rbWasPressed = false;
    private bool ltWasPressed = false;
    private bool rtWasPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        turnOffModels();
        currentShip = 0;
        modelos[currentShip].gameObject.SetActive(true);
        currentColor = playerNum;
        SetShipColor();
    }

    void Update()
    {
        if (Gamepad.all.Count >= playerNum)
        {
            gamepad = Gamepad.all[playerNum];
            
            bool lbPressed = gamepad.leftShoulder.isPressed;
            bool rbPressed = gamepad.rightShoulder.isPressed;
            
            float ltValue = gamepad.leftTrigger.ReadValue();
            float rtValue = gamepad.rightTrigger.ReadValue();
            bool ltPressed = ltValue > 0.5f;
            bool rtPressed = rtValue > 0.5f;
            
            if (lbPressed && !lbWasPressed)
            {
                buttonL();
            }
            lbWasPressed = lbPressed;
            
            if (rbPressed && !rbWasPressed)
            {
                buttonR();
            }
            rbWasPressed = rbPressed;
            
            if (ltPressed && !ltWasPressed)
            {
                colorL();
            }
            ltWasPressed = ltPressed;

            if (rtPressed && !rtWasPressed)
            {
                colorR();
            }
            rtWasPressed = rtPressed;
        }
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
