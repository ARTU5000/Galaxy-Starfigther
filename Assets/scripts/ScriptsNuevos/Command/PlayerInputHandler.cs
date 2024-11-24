using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Transform P1NS;
    public Transform P2NS;
    public Transform P1HS;
    public Transform P2HS;

    public PlayerObjectPool NS1ObjectPool;
    public PlayerObjectPool HS1ObjectPool;
    public PlayerObjectPool NS2ObjectPool;
    public PlayerObjectPool HS2ObjectPool;

    public float movementSpeed = 5f;
    public float rotationSpeed = 360f;

    public float nsCooldown = 0.5f;
    public float hsCooldown = 0.5f;

    private float p1nsNextShootTime = 0f;
    private float p2nsNextShootTime = 0f;
    private float p1hsNextShootTime = 0f;
    private float p2hsNextShootTime = 0f;

    private void Awake()
    {
        player1 = GameObject.FindWithTag("Player").transform;   // asigna el jugador 1
        player2 = GameObject.FindWithTag("Player2").transform; // asigna el jugador 2
        P1NS = GameObject.FindWithTag("P1NS").transform;   // asigna el jugador 1
        P2NS = GameObject.FindWithTag("P2NS").transform; // asigna el jugador 2
        P1HS = GameObject.FindWithTag("P1HS").transform;   // asigna el jugador 1
        P2HS = GameObject.FindWithTag("P2HS").transform; // asigna el jugador 2
    }

    void Update()
    {
        HandlePlayer1Input();
        HandlePlayer2Input();
    }

    private void HandlePlayer1Input()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalP1"), 0, Input.GetAxis("VerticalP1"));//movimiento jugador 1
        if (direction != Vector3.zero)
        {
            ICommand moveCommand = new MoveCommand(player1, direction, movementSpeed, rotationSpeed);
            moveCommand.Execute();
        }

        if (Input.GetButtonDown("Fire3P1"))//disparo normal jugador 1
        {
            if (Time.time >= p1nsNextShootTime)
            {
                ICommand shootCommand = new ShootCommand(NS1ObjectPool, P1NS);
                shootCommand.Execute();

                p1nsNextShootTime = Time.time + (nsCooldown/2);
            }
        }

        if (Input.GetButtonDown("Fire2P1"))//disparo pesado jugador 1
        {
            if (Time.time >= p1hsNextShootTime)
            {
                ICommand shootCommand = new ShootCommand(HS1ObjectPool, P1HS);
                shootCommand.Execute();

                p1hsNextShootTime = Time.time + hsCooldown;
            }
        }
    }

    private void HandlePlayer2Input()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalP2"), 0, Input.GetAxis("VerticalP2"));//movimiento jugador 2
        if (direction != Vector3.zero)
        {
            ICommand moveCommand = new MoveCommand(player2, direction, movementSpeed, rotationSpeed);
            moveCommand.Execute();
        }

        if (Input.GetButtonDown("Fire3P2"))//disparo normal jugador 2
        {
            if (Time.time >= p2nsNextShootTime)
            {
                ICommand shootCommand = new ShootCommand(NS2ObjectPool, P2NS);
                shootCommand.Execute();

                p2nsNextShootTime = Time.time + (nsCooldown/2);
            }
        }

        if (Input.GetButtonDown("Fire2P2"))//disparo pesado jugador 2
        {
            if (Time.time >= p2hsNextShootTime)
            {
                ICommand shootCommand = new ShootCommand(HS2ObjectPool, P2HS);
                shootCommand.Execute();

                p2hsNextShootTime = Time.time + hsCooldown;
            }
        }
    }
}
