using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject fragment;
    public int number;

    private float radius = 1f; 
    private float initialRotation = 0f; 
    private float rotationIncrement;
    
    void Start()
    {
        if (number < 1)
            number = 1;

        rotationIncrement = 360 / number;
    }
    
    public void fragmentsSpawn()
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(fragment, transform.position, Quaternion.identity);
        }
    }
}
