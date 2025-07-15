using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Transform player;
    public Transform PNS;
    public Transform PHS;

    //Objectpools
    public PlayerObjectPool NS1ObjectPool;
    public PlayerObjectPool HS1ObjectPool;

    //Valores numéricos
    public float movementSpeed = 50f;
    public float rotationSpeed = 600f;

    public float nsCooldown = 0.3f;
    public float hsCooldown = 0.6f;

    private float p1nsNextShootTime = 0f;
    private float p1hsNextShootTime = 0f;

    //Axix y botones
    public string horizontal;
    public string vertical;
    public string fireN;
    public string fireH;
    public string fireP;

    //textos de busqueda
    public string tagPlayer;
    public string tagPNS;
    public string tagPHS;

    //numero de jugador
    public int PlayerNum;

    //script power up
    public PlayerPower PPower;

    private void Awake()
    {
        //PPower = this.GetComponent<PlayerPower>();
    }

    void Update()
    {
        HandlePlayer1Input();
    }

    private void HandlePlayer1Input()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw(horizontal), 0, Input.GetAxisRaw(vertical));//movimiento jugador 
        if (direction != Vector3.zero)
        {
            ICommand moveCommand = new MoveCommand(player, direction, movementSpeed, rotationSpeed);
            moveCommand.Execute();
        }

        if (Input.GetAxisRaw(fireN) > 0)//disparo normal jugador 
        {
            if (Time.time >= p1nsNextShootTime)
            {
                ICommand shootCommand = new ShootCommand(NS1ObjectPool, PNS);
                shootCommand.Execute();

                p1nsNextShootTime = Time.time + (nsCooldown / 2);
            }
        }

        if (Input.GetAxisRaw(fireH) > 0)//disparo pesado jugador 
        {
            if (Time.time >= p1hsNextShootTime)
            {
                ICommand shootCommand = new ShootCommand(HS1ObjectPool, PHS);
                shootCommand.Execute();

                p1hsNextShootTime = Time.time + hsCooldown;
            }
        }

        if (Input.GetAxisRaw(fireP) > 0)
        { Debug.Log("AAA"); }

        if (Input.GetAxisRaw(fireP) > 0 && PPower.hasPower)//uso de PowerUp
        {
            PPower.UsePower(PlayerNum);
            Debug.Log(PlayerNum);
        }
    }

    public void AssignControllerInputs()
    {
        switch (PlayerNum)
        {
            case 0:
                horizontal = "HorizontalP1";
                vertical = "VerticalP1";
                fireN = "Fire1P1";
                fireH = "Fire2P1";
                fireP = "PowerP1";
                break;
            case 1:
                horizontal = "HorizontalP2";
                vertical = "VerticalP2";
                fireN = "Fire1P2";
                fireH = "Fire2P2";
                fireP = "PowerP2";
                break;
            case 2:
                horizontal = "HorizontalP3";
                vertical = "VerticalP3";
                fireN = "Fire1P3";
                fireH = "Fire2P3";
                fireP = "PowerP3";
                break;
            case 3:
                horizontal = "HorizontalP4";
                vertical = "VerticalP4";
                fireN = "Fire1P4";
                fireH = "Fire2P4";
                fireP = "PowerP4";
                break;
            default:
                break;
        }
    }
}