using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private Transform player;
    private Vector3 direction;
    private float speed;
    private float rotationSpeed;

    public MoveCommand(Transform _player, Vector3 _direction, float _speed, float _rotationSpeed)
    {
        player = _player;
        direction = _direction.normalized;
        speed = _speed;
        rotationSpeed = _rotationSpeed;
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
    }
}
