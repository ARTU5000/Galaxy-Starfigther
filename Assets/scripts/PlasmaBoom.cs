using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBoom : MonoBehaviour
{
    public float thrust;
    Rigidbody rb;

    public float timer;
    private float end;

    void Awake ()
    {
        rb = GetComponent <Rigidbody>();
    }

    private void OnEnable()
    {
        end = Time.time + timer;
    }

    void Update()
    {
        if (Time.time >= end)
        {
            Destroy(gameObject);
        }
        
        if (transform.position.y != 2f)
        {
            Vector3 fixedPosition = transform.position;
            fixedPosition.y = 2f;
            transform.position = fixedPosition;
        }
    }

    void FixedUpdate ()
    {
        rb.velocity = transform.forward * thrust;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}