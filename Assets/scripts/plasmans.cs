using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plasmans : MonoBehaviour
{
    
    public float thrust;
    Rigidbody rb;

    
    void Start ()
    {
        rb = GetComponent <Rigidbody>();
        Destroy(gameObject,.5f);
    }

    void Update ()
    {
        rb.AddRelativeForce(new Vector3(0,0,thrust * (Time.deltaTime + 2f)));
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        Destroy(gameObject);
    }
}