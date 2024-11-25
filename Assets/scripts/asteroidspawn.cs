using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidspawn : MonoBehaviour
{
    public GameObject asteroid;
    public float x1;
    public float x2;
    private float next;
    public float spawn;
    private bool spawner;
    private Factory aFactory; //Fabrica
    public int totalInGroup;
    public float y;
    public float z;

    void Start()
    {
        aFactory = new Factory();
        spawner = true;
    }

    void SetClone(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject clone = aFactory.CreateIA(asteroid); //pide un asteroide a la fábrica

            float posX = Random.Range(x1, x2);
            clone.transform.position = new Vector3(posX, y, z);
        }
    }
    void Update()
    {
        if(spawner && Time.time>=next )
        {
            SetClone(totalInGroup);
            spawner = false;
        }
        else if (!spawner)
        {
            next = Time.time + spawn;
            spawner = true;
        }
    }
}
