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
    public GameObject projectilePrefab;
    public GameObject heavyProjectilePrefab;
    public float movementSpeed = 5f;
    public float rotationSpeed = 360f;

    private float player1ShootCooldown = 0.5f;
    private float player1NextShootTime = 0f;
    private float player2ShootCooldown = 0.5f;
    private float player2NextShootTime = 0f;

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
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalP1"), 0, Input.GetAxis("VerticalP1"));
        if (direction != Vector3.zero)
        {
            ICommand moveCommand = new MoveCommand(player1, direction, movementSpeed, rotationSpeed);
            moveCommand.Execute();
        }

        if (Input.GetButtonDown("Fire3P1"))
        {
            ICommand shootCommand = new ShootCommand(projectilePrefab, P1NS, player1ShootCooldown, player1NextShootTime);
            shootCommand.Execute();
        }

        if (Input.GetButtonDown("Fire2P1"))
        {
            ICommand heavyShootCommand = new HeavyShootCommand(heavyProjectilePrefab, P1HS, player1ShootCooldown, player1NextShootTime);
            heavyShootCommand.Execute();
        }
    }

    private void HandlePlayer2Input()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalP2"), 0, Input.GetAxis("VerticalP2"));
        if (direction != Vector3.zero)
        {
            ICommand moveCommand = new MoveCommand(player2, direction, movementSpeed, rotationSpeed);
            moveCommand.Execute();
        }

        if (Input.GetButtonDown("Fire3P2"))
        {
            ICommand shootCommand = new ShootCommand(projectilePrefab, P2NS, player2ShootCooldown, player2NextShootTime);
            shootCommand.Execute();
        }

        if (Input.GetButtonDown("Fire2P2"))
        {
            ICommand heavyShootCommand = new HeavyShootCommand(heavyProjectilePrefab, P2HS, player1ShootCooldown, player1NextShootTime);
            heavyShootCommand.Execute();
        }
    }
}
