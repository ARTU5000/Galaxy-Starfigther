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
            for (int i = 0; i < 5; i++)
                Instantiate(fragment, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") && contador >= 6)
            final = true;
        else if (collision.gameObject.CompareTag("Asteroid") && contador < 6)
            contador++;
        else 
            final = true;
    }

}
