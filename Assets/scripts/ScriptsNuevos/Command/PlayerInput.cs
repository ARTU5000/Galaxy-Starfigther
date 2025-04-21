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

    //textos de busqueda
    public string tagPlayer;
    public string tagPNS;
    public string tagPHS;

    //numero de jugador
    public int PlayerNum;

    private void Awake()
    {
        player = GameObject.FindWithTag(tagPlayer).transform;   // asigna el jugador 1
        PNS = GameObject.FindWithTag(tagPNS).transform;   // asigna el jugador 1
        PHS = GameObject.FindWithTag(tagPHS).transform;   // asigna el jugador 1
    }

    void Update()
    {
        HandlePlayer1Input();
    }

    private void HandlePlayer1Input()
    {
        Vector3 direction = new Vector3(Input.GetAxis(horizontal), 0, Input.GetAxis(vertical));//movimiento jugador 
        if (direction != Vector3.zero)
        {
            ICommand moveCommand = new MoveCommand(player, direction, movementSpeed, rotationSpeed);
            moveCommand.Execute();
        }

        if (Input.GetAxis(fireN) > 0)//disparo normal jugador 
        {
            if (Time.time >= p1nsNextShootTime)
            {
                ICommand shootCommand = new ShootCommand(NS1ObjectPool, PNS);
                shootCommand.Execute();

                p1nsNextShootTime = Time.time + (nsCooldown / 2);
            }
        }

        if (Input.GetAxis(fireN) < 0)//disparo pesado jugador 
        {
            if (Time.time >= p1hsNextShootTime)
            {
                ICommand shootCommand = new ShootCommand(HS1ObjectPool, PHS);
                shootCommand.Execute();

                p1hsNextShootTime = Time.time + hsCooldown;
            }
        }
    }
}