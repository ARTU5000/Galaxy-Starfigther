using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plasmahs : MonoBehaviour
{
    public float thrust;
    Rigidbody rb;

    public float timer;
    private float end;

    void Awake ()
    {
        rb = GetComponent <Rigidbody>();
    }

    void Start ()
    {
        Invoke("OnDisable",1f);
    }

    private void OnEnable()
    {
        end = Time.time + timer;
    }

    void Update()
    {
        if (Time.time >= end)
        {
            OnDisable();
        }
    }

    void FixedUpdate ()
    {
        rb.velocity = transform.forward * thrust;
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnDisable();
    }
    
    private void OnDisable()
    {
        // Reinicia transform y velocidad
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;

        gameObject.SetActive(false);
    }
}

