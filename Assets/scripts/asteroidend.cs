using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidend : MonoBehaviour
{
    private bool final = false;
    public GameObject fragment;
    private float end;
    private int contador = 0;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(20, 40);

        end = Time.time + timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= end)
        {
            final = true;   
        }
        
        if (final == true)
        {
            Instantiate(fragment, transform.position, Quaternion.identity);
            Instantiate(fragment, transform.position, Quaternion.identity);
            Instantiate(fragment, transform.position, Quaternion.identity);
            Instantiate(fragment, transform.position, Quaternion.identity);
            Instantiate(fragment, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            final = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            final = true;
        }

        if (collision.gameObject.CompareTag("Heavy_shoot") || collision.gameObject.CompareTag("Normal_shoot"))
        {
            final = true;
        }

        if (collision.gameObject.CompareTag("Asteroid") && contador == 6)
        {
            final = true;
        }
        else
        {
            contador++;
        }
    }

}
