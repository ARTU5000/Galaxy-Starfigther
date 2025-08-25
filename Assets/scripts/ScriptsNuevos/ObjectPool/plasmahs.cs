using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plasmahs : MonoBehaviour
{
    public float thrust;
    Rigidbody rb;

    public float timer;
    private float end;

    public GameObject fragment;
    public int number;

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
            fragmentsSpawn();
            OnDisable();
        }
    }

    void FixedUpdate ()
    {
        rb.velocity = transform.forward * thrust;
    }

    private void OnCollisionEnter(Collision collision)
    {
        fragmentsSpawn();
        OnDisable();
    }
    
    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        
        gameObject.SetActive(false);
    }

    private void fragmentsSpawn()
    {
        if (fragment != null)
        {
            
            CameraShake.instance.Shake(0.2f, 4f);
                
            Vector3 originalPosition = transform.position;
            Quaternion originalRotation = transform.rotation;

            float radius = 3f;
            float heightIncrement = 0.5f;
            float rotationIncrement = 360 / number;

            for (int i = 0; i < number; i++)
            {
                float angle = i * Mathf.PI * 2 / (number / 2f);
                float currentRadius = radius * (1 - (float)i / number);

                Vector3 spawnPos = originalPosition + new Vector3(Mathf.Cos(angle) * currentRadius, i * heightIncrement, Mathf.Sin(angle) * currentRadius);

                float currentRotation = i * rotationIncrement;
                Quaternion spawnRot = Quaternion.Euler(0, currentRotation, 0);

                Instantiate(fragment, spawnPos, spawnRot);
            }
        }
    }
}

