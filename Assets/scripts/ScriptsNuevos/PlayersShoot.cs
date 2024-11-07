using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersShoot : MonoBehaviour
{   
    //puntos de disparo del jugador 1
    public GameObject NSP1;
    public GameObject HSP1;

    //puntos de disparo del jugador 2
    public GameObject NSP2;
    public GameObject HSP2;

    //tipos de disparo (prefabs)
    public GameObject NS;
    public GameObject HS;

    //variables varias
    private float next;
    private int total = 24;
    private int recharge = 1;
    private int Heat;
    private bool fire = true;
    public float shootvel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3P1"))
        {
            if (fire == true)
            {
                Instantiate(NS, NSP1.transform.position, NSP1.transform.rotation);
                Heat += 1;
                if (Heat < total)
                {
                    fire = false;
                }
            }
            else if (fire == false)
            {
                next = Time.time + recharge;
                Heat = 0;
                fire = true;
            }
        }

        if (Input.GetButtonDown("Fire3P2"))
        {
            if (fire == true)
            {
                Instantiate(NS, NSP2.transform.position, NSP2.transform.rotation);
                Heat += 1;
                if (Heat < total)
                {
                    fire = false;
                }
            }
            else if (fire == false)
            {
                next = Time.time + recharge;
                Heat = 0;
                fire = true;
            }
        }

        if (Input.GetButtonDown("Fire2P1"))
        {
            if (fire == true && Time.time >= next)
            {
                Instantiate(HS, HSP1.transform.position, HSP1.transform.rotation);
                next = Time.time + shootvel;
                Heat += 1;
                if (Heat < total)
                {
                    fire = false;
                }
            }
            else if (fire == false)
            {
                next = Time.time + recharge;
                Heat = 0;
                fire = true;
            }
        }

        if (Input.GetButtonDown("Fire2P2"))
        {
            if (fire == true && Time.time >= next)
            {
                Instantiate(HS, HSP2.transform.position, HSP2.transform.rotation);
                next = Time.time + shootvel;
                Heat += 1;
                if (Heat < total)
                {
                    fire = false;
                }
            }
            else if (fire == false)
            {
                next = Time.time + recharge;
                Heat = 0;
                fire = true;
            }
        }
    }
}
