using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private Transform player;
    private Vector3 direction;
    private float speed;
    private float rotationSpeed;
    private Camera mainCamera;

    public MoveCommand(Transform _player, Vector3 _direction, float _speed, float _rotationSpeed)
    {
        player = _player;
        direction = _direction.normalized;
        speed = _speed;
        rotationSpeed = _rotationSpeed;
        mainCamera = Camera.main;
    }

    public void Execute()
    {
        // Movimiento
        player.Translate(direction * speed * Time.deltaTime, Space.World);

        // Rotación
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            player.rotation = Quaternion.RotateTowards(player.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        
        MoveLimits();
    }
    private void MoveLimits()
    {
        Vector3 playerPosition = player.position;

        // Obtener los bordes de la cámara en espacio mundial
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.transform.position.y));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.transform.position.y));

        // Limitar la posición del jugador
        playerPosition.x = Mathf.Clamp(playerPosition.x, bottomLeft.x, topRight.x);
        playerPosition.z = Mathf.Clamp(playerPosition.z, bottomLeft.z, topRight.z);

        // Asignar la posición limitada
        player.position = playerPosition;
    }
}
