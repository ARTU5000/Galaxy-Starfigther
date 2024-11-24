using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyShootCommand : ICommand
{
    private PlayerObjectPool objectPool;
    private Transform spawnPoint;

    public HeavyShootCommand(PlayerObjectPool _objectPool, Transform _spawnPoint)
    {
        objectPool = _objectPool;
        spawnPoint = _spawnPoint;
    }

    public void Execute()
    {//Toma proyectiles de un object pool
        GameObject projectile = objectPool.Spawn();
        if (projectile != null)
        {
            projectile.transform.position = spawnPoint.position;
            projectile.transform.rotation = spawnPoint.rotation;
        }
    }
}
