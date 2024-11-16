using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyShootCommand : ICommand
{
    private GameObject _projectilePrefab;
    private Transform _spawnPoint;
    private float _cooldown;
    private float _nextShootTime;

    public HeavyShootCommand(GameObject projectilePrefab, Transform spawnPoint, float cooldown, float nextShootTime)
    {
        _projectilePrefab = projectilePrefab;
        _spawnPoint = spawnPoint;
        _cooldown = cooldown;
        _nextShootTime = nextShootTime;
    }

    public void Execute()
    {
        if (Time.time >= _nextShootTime)
        {
            Object.Instantiate(_projectilePrefab, _spawnPoint.position, _spawnPoint.rotation);
            _nextShootTime = Time.time + _cooldown;
        }
    }
}
