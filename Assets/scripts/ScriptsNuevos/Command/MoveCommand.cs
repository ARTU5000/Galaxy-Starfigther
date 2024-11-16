using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private Transform _player;
    private Vector3 _direction;
    private float _speed;
    private float _rotationSpeed;

    public MoveCommand(Transform player, Vector3 direction, float speed, float rotationSpeed)
    {
        _player = player;
        _direction = direction.normalized;
        _speed = speed;
        _rotationSpeed = rotationSpeed;
    }

    public void Execute()
    {
        // Movimiento
        _player.Translate(_direction * _speed * Time.deltaTime, Space.World);

        // Rotación
        if (_direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(_direction, Vector3.up);
            _player.rotation = Quaternion.RotateTowards(_player.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}
