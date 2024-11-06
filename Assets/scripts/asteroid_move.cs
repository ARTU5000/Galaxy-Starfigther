using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid_move : MonoBehaviour
{
    public float move1;
    public float move2;
    private float movetotal1;
    
    Rigidbody rb;
    

    void Start()
    {
        movetotal1 = Random.Range(move1, move2);
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        rb.AddRelativeForce(new Vector3( 0,movetotal1, 0));

       
    }


    
}