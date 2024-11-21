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
    private Factory aFactory;
    public int totalInGroup;

    void Start()
    {
        aFactory = new Factory();
    }

    void SetClone(int count)
    {
        GameObject clone = aFactory.CreateIA(asteroid);

        float posX = Random.Range(x1, x2);
        clone.transform.position = new Vector3(posX, 3.6f, 70);
    }
    void Update()
    {
        if(spawner == true && Time.time>=next )
        {
            SetClone(totalInGroup);
            spawner = false;
        }
        else if (spawner == false)
        {
            next = Time.time + spawn;
            spawner = true;
        }
    }
}
